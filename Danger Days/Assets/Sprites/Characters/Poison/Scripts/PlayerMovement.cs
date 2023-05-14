using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Variables

    public PlayerData Data;

    private float moveInput;

    public float lastGroundTime;

    public int WeaponEquip;

    //Config

    [Header("RigidBody")]
    [SerializeField] Rigidbody2D playerRB;

    [Header("Checks")]
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform pistolPoint;
    [SerializeField] Transform riflePoint;
    [SerializeField] Transform bazucaPoint;

    [Header("Layer & Tags")]
    [SerializeField] LayerMask groundLayer;

    [Header("Bullets")]
    [SerializeField] GameObject PistolBullet;
    [SerializeField] GameObject RifleBullet;
    [SerializeField] GameObject BazucaBullet;

    [Header("Other")]
    [SerializeField] public GameObject wheelControl;

    //Codigo

    void Start()
    {
        WeaponEquip = 0;
    }

    void Update()
    {

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

        // Movimiento

        lastGroundTime -= Time.deltaTime;
        moveInput = Input.GetAxisRaw("Horizontal");

        // Salto

        if (isGrounded())
        {
            lastGroundTime = 0.1f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jump();
        }

        //Disparo

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // Flip

        flip();
    }

    void FixedUpdate()
    {
        Movement();
    }

    // Receptor de seleccion de arma

    public void WeaponActive(int WeaponActive)
    {
        WeaponEquip = WeaponActive;

    }

    // Disparo

    void Shoot()
    {
        switch (WeaponEquip)
        {
            case 0:
                Instantiate(PistolBullet, pistolPoint.position, pistolPoint.rotation);
                break;
            case 1:
                Instantiate(RifleBullet, riflePoint.position, riflePoint.rotation);
                break;
            case 3:
                Instantiate(BazucaBullet, bazucaPoint.position, bazucaPoint.rotation);
                break;
        }
    }

    //Movimiento sexual

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

    //GroundChecker

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Girar el personaje segun direccion

    void flip()
    {
        if (Data.isFacingRight && moveInput < 0f || !Data.isFacingRight && moveInput > 0f)
        {
            Data.isFacingRight = !Data.isFacingRight;
            transform.Rotate(0, 180, 0);
        }
    }



}
