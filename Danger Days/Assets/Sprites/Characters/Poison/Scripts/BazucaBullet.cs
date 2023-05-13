using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazucaBullet : MonoBehaviour
{

    [HideInInspector] public PlayerData Data;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
