using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float ValueCarbon;
    [SerializeField] float ScoreCarbon;
    [Space(5)]
    [SerializeField] float ValueGasoline;
    [SerializeField] float ScoreGasoline;

    public PlayerMovement playermovement;

    public PlayerData Data;

    public Collider2D Cemen;

    void Start()
    {
        Data = GetComponent<PlayerData>();
        playermovement = GetComponent<PlayerMovement>();
    }

    public void OnTriggerEnter2D(Collider2D Touch)
    {

        switch (Touch.tag)
        {
            case "Carbon":
                Data.Carbons += ValueCarbon;
                Data.Score += ScoreCarbon;
                Destroy(Touch.gameObject);
                FindObjectOfType<AudioManager>().Play("Coin");
                break;
            case "Gasoline":
                Data.Gasoline += ValueGasoline;
                Data.Score += ScoreGasoline;
                Destroy(Touch.gameObject);
                FindObjectOfType<AudioManager>().Play("Collectible");
                break;
            case "Chronomita":
                Data.Gasoline += ValueGasoline;
                Data.Score += ScoreCarbon;
                Destroy(Touch.gameObject);
                FindObjectOfType<AudioManager>().Play("Collectible");
                break;
            case "Pinchos":
                playermovement.getDamage(Data.MaxHealth);
                break;
        }
    }
}
