using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazucaBullet : MonoBehaviour
{
    [HideInInspector] public PlayerData Data;
    [HideInInspector] public Rigidbody2D BazucaRB;

    [Header("Adicionales")]
    [SerializeField] public GameObject HitEffect;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        BazucaRB = GetComponent<Rigidbody2D>();
        BazucaRB.velocity = transform.right * Data.bazucaBulletSpeed;
    }

    // Funcion de deteccion de colision Bala

    void OnTriggerEnter2D(Collider2D BazucaHit)
    {
        if (BazucaHit.tag != "MachineGame" && BazucaHit.tag != "Carbon" && BazucaHit.name != "PistolaBala(Clone)" && BazucaHit.name != "RifleBala(Clone)" && BazucaHit.name != "BazucaBala(Clone)" && BazucaHit.tag != "Player")
        {
            DraculoidMovement Draculoid = BazucaHit.GetComponent<DraculoidMovement>();
            if (Draculoid != null)
            {
                Draculoid.getDamage(Data.bazucaBulletDamage);
            }

            Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (BazucaHit.tag == "WoodDoor")
        {
            WoodenDoor Door = BazucaHit.GetComponent<WoodenDoor>();
            Door.woodDamage();
        }
    }
}
