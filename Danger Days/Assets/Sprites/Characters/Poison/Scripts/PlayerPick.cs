using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] public int Carbon;

    private void OnTriggerEnter2D(Collider2D Touch)
    {
        switch (Touch.tag)
        {
            case "Carbon":
                Destroy(Touch.gameObject);
                break;
            case "Gasoline":
                Destroy(Touch.gameObject);
                break;
        }
    }
}
