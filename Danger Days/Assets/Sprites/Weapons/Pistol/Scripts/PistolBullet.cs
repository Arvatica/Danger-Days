using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    [HideInInspector] public PlayerData Data;
    [HideInInspector] public Rigidbody2D PistolRB;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        PistolRB = GetComponent<Rigidbody2D>();
        PistolRB.velocity = transform.right * Data.pistolBulletSpeed;
    }
}
