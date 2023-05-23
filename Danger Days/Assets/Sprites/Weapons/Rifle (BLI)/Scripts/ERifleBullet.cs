using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERifleBullet : MonoBehaviour
{
    [HideInInspector] public DraculoidData Data;
    [HideInInspector] public PlayerMovement Player;
    [HideInInspector] public Rigidbody2D ERifleRB;

    [Header("Adicionales")]
    [SerializeField] public GameObject HitEffect;
    [SerializeField] public GameObject Poison;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Draculoid").GetComponent<DraculoidData>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Poison = GameObject.FindGameObjectWithTag("Player");
        ERifleRB = GetComponent<Rigidbody2D>();

        Vector3 direction = Player.transform.position - transform.position;
        ERifleRB.velocity = new Vector2(direction.x, direction.y).normalized * Data.pistolBulletSpeed;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Funcion de deteccion de colision Bala

    void OnTriggerEnter2D(Collider2D RifleHit)
    {
        if (RifleHit.tag != "Carbon" && RifleHit.name != "EPistolaBala(Clone)" && RifleHit.name != "ERifleBala(Clone)" && RifleHit.tag != "Draculoid")
        {
            if (Player != null && RifleHit.tag == "Player")
            {
                Player.getDamage(Data.rifleBulletDamage);
            }
            if (RifleHit.tag == "Barrel")
            {
                Barrel Door = RifleHit.GetComponent<Barrel>();
                Door.woodDamage();
            }

            Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
