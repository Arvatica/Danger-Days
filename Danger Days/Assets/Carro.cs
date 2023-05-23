using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D cock)
    {
        if (cock.tag == "Player")
        {
            PlayerMovement Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            Movement.CarroOpenable = true;
        }
    }
}
