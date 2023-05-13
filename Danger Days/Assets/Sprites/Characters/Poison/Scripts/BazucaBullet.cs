using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazucaBullet : MonoBehaviour
{

    [HideInInspector] public PlayerData Data;
    [HideInInspector] public Rigidbody2D BazucaRB;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        BazucaRB = GetComponent<Rigidbody2D>();
        BazucaRB.velocity = transform.right * Data.bazucaBulletSpeed;
    }

}
