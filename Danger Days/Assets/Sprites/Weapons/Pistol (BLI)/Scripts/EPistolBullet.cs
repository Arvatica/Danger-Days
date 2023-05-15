using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPistolBullet : MonoBehaviour
{
    [HideInInspector] public DraculoidData Data;
    [HideInInspector] public Rigidbody2D EPistolRB;

    [Header("Adicionales")]
    [SerializeField] public GameObject HitEffect;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Draculoid").GetComponent<DraculoidData>();
        EPistolRB = GetComponent<Rigidbody2D>();
        EPistolRB.velocity = transform.right * Data.pistolBulletSpeed;
    }

    // Funcion de deteccion de colision Bala

    void OnTriggerEnter2D(Collider2D PistolHit)
    {
        PlayerMovement Player = PistolHit.GetComponent<PlayerMovement>();

        if (PistolHit.name != "EPistolaBala(Clone)" && PistolHit.name != "ERifleBala(Clone)")
        {
            if (Player != null)
            {
                Player.getDamage(Data.pistolBulletDamage);
            }

            Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
