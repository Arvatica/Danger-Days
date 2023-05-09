using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData Data;

    private float moveInput;

    public float lastGroundTime;

    [Header("RigidBody")]
    [SerializeField] Rigidbody2D playerRB;

    [Header("GroundCheck")]
    [SerializeField] Transform groundCheck;

    [Header("Layer & Tags")]
    [SerializeField] LayerMask groundLayer;

    void Update()
    {
        lastGroundTime -= Time.deltaTime;

        moveInput = Input.GetAxisRaw("Horizontal");

        if (isGrounded())
        {
            lastGroundTime = 0.1f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jump();
        }

        flip();
    }

    void FixedUpdate()
    {
        Movement();
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void jump()
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, Data.jumpForce);

        if (Input.GetButtonUp("Jump") && playerRB.velocity.y > 0f)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y * 0.5f);
        }
    }

    void Movement()
    {
        float fullSpeed = moveInput * Data.movementMaxSpeed;

        float accelerationRate;

        if (lastGroundTime > 0)
        {
            accelerationRate = (Mathf.Abs(fullSpeed) > 0.01f) ? Data.AccAmount : Data.DeaccAmount;

        }
        else
        {
            accelerationRate = (Mathf.Abs(fullSpeed) > 0.01f) ? Data.AccAmount * Data.AcceAir : Data.DeaccAmount * Data.DeaccAir;
        }

        float speedDif = fullSpeed - playerRB.velocity.x;

        float movement = speedDif * accelerationRate;

        playerRB.AddForce(movement * Vector2.right, ForceMode2D.Force);

    }


    void flip()
    {
        if (Data.isFacingRight && moveInput < 0f || !Data.isFacingRight && moveInput > 0f)
        {
            Data.isFacingRight = !Data.isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
