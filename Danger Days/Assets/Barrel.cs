using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] int ObjHealth;
    public GameObject Explosion;
    public void woodDamage()
    {
        ObjHealth -= 1;

        if (ObjHealth == 0)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
