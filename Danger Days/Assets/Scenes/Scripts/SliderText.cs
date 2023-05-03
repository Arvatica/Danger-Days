using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderText : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text Text;
    private float Number;

    void Start()
    {
        Number = slider.value;
        Text.text = Number.ToString();
    }

    public void Value()
    {
        Number = slider.value;
        Text.text = Number.ToString();
    }

}
