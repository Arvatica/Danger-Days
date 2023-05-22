using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraculoidMovement : MonoBehaviour
{
    //Variables

    public DraculoidData Data;
    private GameObject Poison;
    private bool isFacingRight = true;
    private float timer;
    private float timer2;


    // Config

    [Header("RigidBody")]
    [SerializeField] Rigidbody2D draculoidRB;

    [Header("Animator")]
    [SerializeField] Animator DracAnimator;

    [Header("Checks")]
    [SerializeField] Transform pistolPoint;
    [SerializeField] Transform riflePoint;
    [SerializeField] Transform feetPoint;

    [Header("Gizmos")]
    [SerializeField] float GroundDistance;

    [Header("Bullets")]
    [SerializeField] GameObject EPistolBullet;
    [SerializeField] GameObject ERifleBullet;

    void Awake()
    {
        Poison = GameObject.FindGameObjectWithTag("Player");
        timer = Data.timing;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, Poison.transform.position);

        timer -= Time.deltaTime;

        DracAnimator.SetInteger("Weapon", Data.WeaponEquip);

        if (distance < Data.Radious)
        {
            if (Data.WeaponEquip == 0)
            {

                timer -= Time.deltaTime;
                StopCoroutine(rifleShoot());


                if (timer < 0)
                {
                    timer = Data.timing;
                    Shoot();
                }

            }
            else if (Data.WeaponEquip == 1)
            {
                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    timer = Data.timing;
                    timer2 = 0;
                    StartCoroutine(rifleShoot());
                }
            }

        }


    }

    // Corutina Rifle

    IEnumerator rifleShoot()
    {
        if (timer2 < Data.rifleQuantity)
        {
            timer2 += 1;
            yield return new WaitForSeconds(Data.rifleAttackSpeed);
            Shoot();
            StartCoroutine(rifleShoot());
        }
        if (timer > Data.rifleQuantity)
        {
            StopCoroutine(rifleShoot());
        }

    }

    // Disparo

    void Shoot()
    {
        switch (Data.WeaponEquip)
        {
            case 0:
                Instantiate(EPistolBullet, pistolPoint.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(ERifleBullet, riflePoint.position, Quaternion.identity);
                break;
        }
    }



    // Movimiento // Detecta si hay o no vacio y/o colision 

    void FixedUpdate()
    {
        RaycastHit2D ground = Physics2D.Raycast(feetPoint.position, Vector2.down, GroundDistance);
        draculoidRB.velocity = new Vector2((Data.draculoidSpeed * Data.horizontal), draculoidRB.velocity.y);

        if (ground == false)
        {
            flip();
        }

    }

    // Flip

    void flip()
    {
        Data.horizontal *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180, 0);
    }

    // Linea Pies

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(feetPoint.transform.position, feetPoint.transform.position + Vector3.down * GroundDistance);
    }

    // Funcion para recibir dmg

    public void getDamage(int Damage)
    {
        Data.Health -= Damage;

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
