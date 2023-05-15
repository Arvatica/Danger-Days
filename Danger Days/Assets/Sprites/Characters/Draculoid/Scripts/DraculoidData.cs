using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraculoidData : MonoBehaviour
{
    [Header("Stats")]
    public int Health;


    [Header("Movement")]
    public float draculoidSpeed;
    public float horizontal = 1;



    [Header("Weapon Manager")]
    [Header("Pistol")]
    public float pistolBulletSpeed;
    public int pistolBulletDamage;
    [Space(5)]
    [Header("Rifle")]
    public float rifleBulletSpeed;
    public int rifleBulletDamage;

}
