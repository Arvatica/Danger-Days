using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] int ValueCarbon;
    [SerializeField] int ScoreCarbon;
    [Space(5)]
    [SerializeField] int ValueGasoline;
    [SerializeField] int ScoreGasoline;

    public PlayerData Data;

    void Start()
    {
        Data = GetComponent<PlayerData>();
    }

    private void OnTriggerEnter2D(Collider2D Touch)
    {
        switch (Touch.tag)
        {
            case "Carbon":
                Data.Carbons += ValueCarbon;
                Data.Score += ScoreCarbon;
                Destroy(Touch.gameObject);
                break;
            case "Gasoline":
                Data.Gasoline += ValueGasoline;
                Data.Score += ScoreGasoline;
                Destroy(Touch.gameObject);
                break;
        }
    }
}
