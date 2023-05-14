using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Sin explicaciones

public class WheelItems : MonoBehaviour
{

    public Color hoverColor;
    public Color baseColor;
    public Image bg;
    public Animator anim;

    void Start()
    {
        bg.color = baseColor;
    }

    public void Selected()
    {
        bg.color = hoverColor;
        anim.SetBool("Select", true);
    }

    public void Deselected()
    {
        bg.color = baseColor;
        anim.SetBool("Select", false);
    }
}
