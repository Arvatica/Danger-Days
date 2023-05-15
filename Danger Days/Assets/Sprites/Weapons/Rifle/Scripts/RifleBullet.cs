using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    [HideInInspector] public PlayerData Data;
    [HideInInspector] public Rigidbody2D RifleRB;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        RifleRB = GetComponent<Rigidbody2D>();
        RifleRB.velocity = transform.right * Data.rifleBulletSpeed;
    }
}
