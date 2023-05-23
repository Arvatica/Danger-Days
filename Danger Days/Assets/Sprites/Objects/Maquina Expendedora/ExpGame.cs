using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D cock)
    {
        if (cock.tag == "Player")
        {
            PlayerMovement Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            Movement.MachineOpenable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            Movement.MachineOpenable = false;
        }
    }
}
