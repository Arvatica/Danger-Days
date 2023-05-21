using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleSelfDestroy : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
