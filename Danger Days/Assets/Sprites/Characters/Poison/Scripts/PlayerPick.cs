using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    [Header("Puntajes")]
    [SerializeField] public int Carbon;


    private void OnTriggerEnter2D(Collider2D Touch)
    {
        switch (Touch.tag)
        {
            case "Coin":
                Destroy(Touch.gameObject);
                break;
        }
    }
}
