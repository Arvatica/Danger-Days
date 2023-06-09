using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    [HideInInspector] public PlayerData Data;
    [HideInInspector] public Rigidbody2D PistolRB;

    [Header("Adicionales")]
    [SerializeField] public GameObject HitEffect;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        PistolRB = GetComponent<Rigidbody2D>();
        PistolRB.velocity = transform.right * Data.pistolBulletSpeed;
    }

    // Funcion de deteccion de colision Bala

    void OnTriggerEnter2D(Collider2D PistolHit)
    {
        FindObjectOfType<AudioManager>().Play("BulletHit");

        DraculoidMovement Draculoid = PistolHit.GetComponent<DraculoidMovement>();
        if (PistolHit.tag != "MachineGame" && PistolHit.tag != "Carbon" && PistolHit.name != "PistolaBala(Clone)" && PistolHit.name != "RifleBala(Clone)" && PistolHit.name != "BazucaBala(Clone)" && PistolHit.tag != "Player")
        {
            if (Draculoid != null)
            {
                Draculoid.getDamage(Data.pistolBulletDamage);
            }

            Instantiate(HitEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        if (PistolHit.tag == "WoodDoor")
        {
            WoodenDoor Door = PistolHit.GetComponent<WoodenDoor>();
            Door.woodDamage();
        }
        if (PistolHit.tag == "Mannequin")
        {
            Destroy(PistolHit.gameObject);
        }
        if (PistolHit.tag == "Barrel")
        {
            Barrel Door = PistolHit.GetComponent<Barrel>();
            Door.woodDamage();
        }
    }

    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }

}