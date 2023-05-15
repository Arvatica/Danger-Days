using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider healthSlider;
    [HideInInspector] public PlayerData Data;

    void Start()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        healthSlider.maxValue = Data.Health;
        healthSlider.value = Data.Health;
    }

    public void setHealth()
    {
        healthSlider.value = Data.Health;
    }

}
