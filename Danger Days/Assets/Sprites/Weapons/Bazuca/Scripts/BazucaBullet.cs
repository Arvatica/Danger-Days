using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazucaBullet : MonoBehaviour
{
    [HideInInspector] public PlayerData Data;
    [HideInInspector] public Rigidbody2D BazucaRB;

    [Header("Adicionales")]
    [SerializeField] public GameObject HitEffect;
    [SerializeField] public GameObject Explosion;

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

            Instantiate(Explosion, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Explosion");
            Destroy(gameObject);
        }

        if (BazucaHit.tag == "WoodDoor")
        {
            WoodenDoor Door = BazucaHit.GetComponent<WoodenDoor>();
            Door.woodDamage();
        }

        if (BazucaHit.tag == "Mannequin")
        {
            Destroy(BazucaHit.gameObject);
        }
        if (BazucaHit.tag == "Barrel")
        {
            Barrel Door = BazucaHit.GetComponent<Barrel>();
            Door.woodDamage();
        }
    }
    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }
}
