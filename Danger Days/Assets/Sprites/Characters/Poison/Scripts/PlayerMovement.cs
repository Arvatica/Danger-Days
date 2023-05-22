using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variables

    public PlayerData Data;
    public WeaponDisplay WeaponDisplay;

    private float moveInput;

    public float lastGroundTime;

    public int WeaponEquip;

    private int ObjectEquip = 0;

    private float timeWhenAllowedNextShoot = 0f;

    private float timeBetweenShooting = 0.25f;


    // Config

    [Header("RigidBody")]
    [SerializeField] Rigidbody2D playerRB;

    [Header("Checks")]
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform pistolPoint;
    [SerializeField] Transform riflePoint;
    [SerializeField] Transform bazucaPoint;
    [SerializeField] Transform pistolPointFront;
    [SerializeField] Transform riflePointFront;
    [SerializeField] Transform bazucaPointFront;


    [Header("Layer & Tags")]
    [SerializeField] LayerMask groundLayer;

    [Header("Bullets")]
    [SerializeField] GameObject PistolBullet;
    [SerializeField] GameObject RifleBullet;
    [SerializeField] GameObject BazucaBullet;

    [Header("ShootAnims")]
    [SerializeField] GameObject PistolShoot;
    [SerializeField] GameObject RifleShoot;
    [SerializeField] GameObject BazucaShoot;

    [Header("Other")]
    [SerializeField] public WheelControl wheelControl;
    [SerializeField] public GameObject PauseMenu;
    [SerializeField] bool PauseOpen = false;

    [Header("Animaciones&Objs")]
    [SerializeField] GameObject SideRig;
    [SerializeField] Animator SideAnimator;
    [SerializeField] GameObject FrontRig;
    [SerializeField] Animator FrontAnimator;




    // Codigo

    void Start()
    {
        WeaponEquip = 0;
        WeaponDisplay = GameObject.FindGameObjectWithTag("WeaponDisplay").GetComponent<WeaponDisplay>();
        wheelControl = GameObject.FindGameObjectWithTag("WheelControl").GetComponent<WheelControl>();
        SideAnimator.SetInteger("WeaponEquip", 0);
        PauseMenu = GameObject.FindGameObjectWithTag("Pause");
        PauseMenu.SetActive(PauseOpen);
    }

    void Update()
    {

        // Abrir cerrar menu

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOpen = !PauseOpen;
            PauseMenu.SetActive(PauseOpen);
        }

        // Weapon Wheel

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            wheelControl.GetComponent<WheelControl>().canSelect();
            wheelControl.GetComponent<WheelControl>().Open();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            wheelControl.GetComponent<WheelControl>().canSelect();
            wheelControl.GetComponent<WheelControl>().Close();
        }

        // Cambio de objeto

        if (Input.GetKeyDown(KeyCode.E))
        {
            objectChange();
        }

        // Uso de objeto

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Use Object");
            useObject();

        }

        // Movimiento

        lastGroundTime -= Time.deltaTime;
        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
        {
            SideAnimator.SetBool("IsMoving", true);
            FrontAnimator.SetBool("IsMoving", true);
        }
        if (moveInput == 0)
        {
            SideAnimator.SetBool("IsMoving", false);
            FrontAnimator.SetBool("IsMoving", false);
        }

        // Salto

        if (isGrounded())
        {
            lastGroundTime = 0.1f;
            FrontAnimator.SetBool("IsJumping", false);
            SideAnimator.SetBool("IsJumping", false);
        }
        if (Input.GetButtonDown("Jump") && isGrounded() && lastGroundTime == 0.1f)
        {
            jump();
        }
        if (!isGrounded())
        {
            FrontAnimator.SetBool("IsJumping", true);
            SideAnimator.SetBool("IsJumping", true);
        }

        // Check para poder disparar

        checkIfShouldShoot();

        // Flip

        flip();
    }

    void FixedUpdate()
    {
        Movement();
    }

    // Disparo

    void checkIfShouldShoot()
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
            }
        }
    }

    // Receptor de seleccion de arma

    public void WeaponActive(int WeaponActive)
    {
        WeaponEquip = WeaponActive;
        WeaponDisplay.sort();
        SideAnimator.SetInteger("WeaponEquip", WeaponEquip);
        FrontAnimator.SetInteger("WeaponEquip", WeaponEquip);
    }

    // Disparo

    void Shoot()
    {
        switch (WeaponEquip)
        {
            case 0:
                timeBetweenShooting = 0.6f;
                if (moveInput != 0)
                {
                    Instantiate(PistolBullet, pistolPoint.position, pistolPoint.rotation);
                    Instantiate(PistolShoot, pistolPoint.position, pistolPoint.rotation, pistolPoint);
                }
                if (moveInput == 0)
                {
                    StartCoroutine(ShootFrontal());
                }
                break;
            case 1:
                timeBetweenShooting = 0.2f;
                if (moveInput != 0)
                {
                    Instantiate(RifleBullet, riflePoint.position, riflePoint.rotation);
                    Instantiate(RifleShoot, riflePoint.position, riflePoint.rotation, riflePoint);
                }
                if (moveInput == 0)
                {
                    StartCoroutine(ShootFrontal());
                }
                break;
            case 3:
                timeBetweenShooting = 0.8f;
                if (Data.bazucaAmmo > 0)
                {
                    Data.bazucaAmmo -= 1;
                    WeaponDisplay.Quantity.text = "" + Data.bazucaAmmo;
                    if (moveInput != 0)
                    {
                        Instantiate(BazucaBullet, bazucaPoint.position, bazucaPoint.rotation);
                        Instantiate(BazucaShoot, bazucaPoint.position, bazucaPoint.rotation, bazucaPoint);
                    }
                    if (moveInput == 0)
                    {
                        StartCoroutine(ShootFrontal());
                    }

                }
                break;
        }
    }



    //Delay para disparo frontal

    IEnumerator ShootFrontal()
    {
        FrontAnimator.SetBool("IsShooting", true);
        yield return new WaitForSeconds(0.1f);
        switch (WeaponEquip)
        {
            case 0:
                Instantiate(PistolBullet, pistolPointFront.position, pistolPointFront.rotation);
                Instantiate(PistolShoot, pistolPointFront.position, pistolPointFront.rotation, pistolPointFront);
                break;
            case 1:
                Instantiate(RifleBullet, riflePointFront.position, riflePointFront.rotation);
                Instantiate(RifleShoot, riflePointFront.position, riflePointFront.rotation, riflePointFront);
                break;
            case 3:
                Instantiate(BazucaBullet, bazucaPointFront.position, bazucaPointFront.rotation);
                Instantiate(BazucaShoot, bazucaPointFront.position, bazucaPointFront.rotation, bazucaPointFront);
                break;
        }

        yield return new WaitForSeconds(0.5f);
        FrontAnimator.SetBool("IsShooting", false);
    }



    // Cambio de objeto

    void objectChange()
    {
        if (ObjectEquip == 0)
        {
            ObjectEquip = 1;
            Healthbar healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Healthbar>();
            healthbar.changeSprite(1);
        }
        else if (ObjectEquip == 1)
        {
            ObjectEquip = 0;
            Healthbar healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Healthbar>();
            healthbar.changeSprite(0);
        }
    }

    // Uso de objeto

    void useObject()
    {
        if (ObjectEquip == 0 && Data.Xenitio >= 1 && Data.Health != Data.MaxHealth)
        {
            Data.Health += Data.XenitioHeal;
            Data.Xenitio -= 1;

            if (Data.Health > Data.MaxHealth)
            {
                Data.Health = Data.MaxHealth;
            }
            Healthbar healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Healthbar>();
            healthbar.setHealth();
            healthbar.changeSprite(ObjectEquip);
        }
        else if (ObjectEquip == 1 && Data.Voltageno >= 1 && Data.Health != Data.MaxHealth)
        {
            Data.Health += Data.VoltagenoHeal;
            Data.Voltageno -= 1;
            if (Data.Health > Data.MaxHealth)
            {
                Data.Health = Data.MaxHealth;
            }
            Healthbar healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Healthbar>();
            healthbar.setHealth();
            healthbar.changeSprite(ObjectEquip);

        }
    }

    // Movimiento sexual

    void Movement()
    {
        float fullSpeed = moveInput * Data.movementMaxSpeed;

        float accelerationRate;

        if (lastGroundTime > 0)
        {
            accelerationRate = (Mathf.Abs(fullSpeed) > 0.01f) ? Data.AccAmount : Data.DeaccAmount;

        }
        else
        {
            accelerationRate = (Mathf.Abs(fullSpeed) > 0.01f) ? Data.AccAmount * Data.AcceAir : Data.DeaccAmount * Data.DeaccAir;
        }

        float speedDif = fullSpeed - playerRB.velocity.x;

        float movement = speedDif * accelerationRate;

        playerRB.AddForce(movement * Vector2.right, ForceMode2D.Force);

    }

    //Salto del personaje

    void jump()
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, Data.jumpForce);

        if (Input.GetButtonUp("Jump") && playerRB.velocity.y > 0f)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y * 0.5f);
        }
    }

    // GroundChecker

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    // Girar el personaje segun direccion

    void flip()
    {
        if (Data.isFacingRight && moveInput < 0f || !Data.isFacingRight && moveInput > 0f)
        {
            Data.isFacingRight = !Data.isFacingRight;
            transform.Rotate(0, 180, 0);
        }
    }

    // Funcion para recibir dmg

    public void getDamage(int Damage)
    {
        Data.Health -= Damage;
        Healthbar healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Healthbar>();
        healthbar.setHealth();

        if (Data.Health <= 0)
        {
            Die();
        }
    }

    // FUncion para morir // Destruir

    void Die()
    {
        Destroy(gameObject);
    }

}
