using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERifleBullet : MonoBehaviour
{
    [HideInInspector] public DraculoidData Data;
    [HideInInspector] public Rigidbody2D ERifleRB;

    [Header("Adicionales")]
    [SerializeField] public GameObject HitEffect;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Draculoid").GetComponent<DraculoidData>();
        ERifleRB = GetComponent<Rigidbody2D>();
        ERifleRB.velocity = transform.right * Data.rifleBulletSpeed;
    }

    // Funcion de deteccion de colision Bala

    void OnTriggerEnter2D(Collider2D RifleHit)
    {
        PlayerMovement Player = RifleHit.GetComponent<PlayerMovement>();

        if (RifleHit.name != "EPistolaBala(Clone)" && RifleHit.name != "ERifleBala(Clone)")
        {
            if (Player != null)
            {
                Player.getDamage(Data.rifleBulletDamage);
            }

            Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
