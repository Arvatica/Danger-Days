using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
    public Slider healthSlider;
    [HideInInspector] public PlayerData Data;
    [Header("Matenme")]
    public TMP_Text Cantidad;
    public Image Image;
    public Sprite Xenitio;
    public Sprite Voltageno;

    void Start()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        healthSlider.maxValue = Data.MaxHealth;
        healthSlider.value = Data.MaxHealth;
        changeSprite(0);
    }

    public void setHealth()
    {
        healthSlider.value = Data.Health;
    }

    public void changeSprite(int Object)
    {
        switch (Object)
        {
            case 0:
                Cantidad.text = (Data.Xenitio).ToString();
                Image.sprite = Xenitio;
                break;
            case 1:
                Cantidad.text = (Data.Voltageno).ToString();
                Image.sprite = Voltageno;
                break;
        }
    }
}