using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenDoor : MonoBehaviour
{
    [SerializeField] int ObjHealth;
    [SerializeField] Animator DoorAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjHealth == 0)
        {
            DoorAnim.SetBool("open", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bala"))
        {
            if (ObjHealth < 0)
            {
                ObjHealth -= 1;
            }

        }

    }
}
