using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [HideInInspector] public PlayerData PlayerData;
    [HideInInspector] public PlayerMovement Player;
    [HideInInspector] public DraculoidMovement Draculoid;
    [HideInInspector] public DraculoidData DraculoidData;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        PlayerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        Draculoid = GameObject.FindGameObjectWithTag("Draculoid").GetComponent<DraculoidMovement>();
        DraculoidData = GameObject.FindGameObjectWithTag("Draculoid").GetComponent<DraculoidData>();
        FindObjectOfType<AudioManager>().Play("Explosion");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            Player.getDamage(PlayerData.barreldmg);
        }
        if (collision.tag == "Draculoid1")
        {
            Draculoid.getDamage(DraculoidData.barreldmg);
        }
    }
}
