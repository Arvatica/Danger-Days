using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraculoidMovement : MonoBehaviour
{
    //Variables

    public DraculoidData Data;
    private bool isFacingRight = true;

    // Config

    [Header("RigidBody")]
    [SerializeField] Rigidbody2D draculoidRB;

    [Header("Checks")]
    [SerializeField] Transform pistolPoint;
    [SerializeField] Transform riflePoint;
    [SerializeField] Transform feetPoint;

    [Header("Gizmos")]
    [SerializeField] float GroundDistance;


    // Movimiento // Detecta si hay o no vacio y/o colision 

    void FixedUpdate()
    {
        RaycastHit2D ground = Physics2D.Raycast(feetPoint.position, Vector2.down, GroundDistance);
        draculoidRB.velocity = new Vector2((Data.draculoidSpeed * Data.horizontal), draculoidRB.velocity.y);

        if (ground == false)
        {
            flip();
        }

    }

    // Flip

    void flip()
    {
        Data.horizontal *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180, 0);
    }

    // Linea Pies

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(feetPoint.transform.position, feetPoint.transform.position + Vector3.down * GroundDistance);
    }

    // Funcion para recibir dmg

    public void getDamage(int Damage)
    {
        Data.Health -= Damage;

        if (Data.Health <= 0)
        {
            Die();
        }
    }

    // FUncion para morir // Destruir

    void Die()
    {
        Destroy(gameObject);
    }


}
