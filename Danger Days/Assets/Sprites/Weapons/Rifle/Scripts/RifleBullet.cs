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
        FindObjectOfType<AudioManager>().Play("BulletHit");

        DraculoidMovement Draculoid = RifleHit.GetComponent<DraculoidMovement>();

        if (RifleHit.tag != "MachineGame" && RifleHit.tag != "Carbon" && RifleHit.name != "PistolaBala(Clone)" && RifleHit.name != "RifleBala(Clone)" && RifleHit.name != "BazucaBala(Clone)" && RifleHit.tag != "Player")
        {
            if (Draculoid != null)
            {
                Draculoid.getDamage(Data.rifleBulletDamage);
            }

            Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (RifleHit.tag == "WoodDoor")
        {
            WoodenDoor Door = RifleHit.GetComponent<WoodenDoor>();
            Door.woodDamage();
        }

        if (RifleHit.tag == "Mannequin")
        {
            Destroy(RifleHit.gameObject);
        }

        if (RifleHit.tag == "Barrel")
        {
            Barrel Door = RifleHit.GetComponent<Barrel>();
            Door.woodDamage();
        }
    }

    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }
}
