using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Movement")]
    public float movementMaxSpeed;
    public float movementAcceleration;
    public float movementDeacceleration;
    [Space(5)]
    [Range(0.01f, 1)] public float AcceAir;
    [Range(0.01f, 1)] public float DeaccAir;

    [HideInInspector] public float AccAmount;
    [HideInInspector] public float DeaccAmount;

    [Header("Jump")]
    public float jumpForce;

    [Header("Facing")]
    public bool isFacingRight = true;

    private void OnValidate()
    {
        AccAmount = (50 * movementAcceleration) / movementMaxSpeed;
        DeaccAmount = (50 * movementDeacceleration) / movementMaxSpeed;

        #region Variable Ranges
        movementAcceleration = Mathf.Clamp(movementAcceleration, 0.01f, movementMaxSpeed);
        movementDeacceleration = Mathf.Clamp(movementDeacceleration, 0.01f, movementMaxSpeed);
        #endregion
    }
}
