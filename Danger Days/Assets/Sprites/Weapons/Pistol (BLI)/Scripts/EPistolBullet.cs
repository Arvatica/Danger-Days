using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPistolBullet : MonoBehaviour
{
    [HideInInspector] public DraculoidData Data;
    [HideInInspector] public PlayerMovement Player;
    [HideInInspector] public Rigidbody2D EPistolRB;

    [Header("Adicionales")]
    [SerializeField] public GameObject HitEffect;
    [SerializeField] public GameObject Poison;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Draculoid").GetComponent<DraculoidData>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Poison = GameObject.FindGameObjectWithTag("Player");
        EPistolRB = GetComponent<Rigidbody2D>();

        Vector3 direction = Player.transform.position - transform.position;
        EPistolRB.velocity = new Vector2(direction.x, direction.y).normalized * Data.pistolBulletSpeed;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Funcion de deteccion de colision Bala

    void OnTriggerEnter2D(Collider2D PistolHit)
    {
        if (PistolHit.name != "EPistolaBala(Clone)" && PistolHit.name != "ERifleBala(Clone)" && PistolHit.tag != "Draculoid")
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
