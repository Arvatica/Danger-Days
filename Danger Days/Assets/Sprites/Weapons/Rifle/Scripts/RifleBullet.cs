using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    [HideInInspector] public PlayerData Data;
    [HideInInspector] public Rigidbody2D RifleRB;

    [Header("Adicionales")]
    [SerializeField] public GameObject HitEffect;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        RifleRB = GetComponent<Rigidbody2D>();
        RifleRB.velocity = transform.right * Data.rifleBulletSpeed;
    }

    // Funcion de deteccion de colision Bala

    void OnTriggerEnter2D(Collider2D RifleHit)
    {
        DraculoidMovement Draculoid = RifleHit.GetComponent<DraculoidMovement>();

        if (RifleHit.name != "PistolaBala(Clone)" && RifleHit.name != "RifleBala(Clone)" && RifleHit.name != "BazucaBala(Clone)")
        {
            if (Draculoid != null)
            {
                Draculoid.getDamage(Data.rifleBulletDamage);
            }

            Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
