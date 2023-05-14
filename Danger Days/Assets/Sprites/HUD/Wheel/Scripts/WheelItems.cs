using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelItems : MonoBehaviour
{

    public Color hoverColor;
    public Color baseColor;
    public Image bg;


    void Start()
    {
        bg.color = baseColor;
    }

    public void Selected()
    {
        bg.color = hoverColor;
    }
    public void Deselected()
    {
        bg.color = baseColor;
    }
}
