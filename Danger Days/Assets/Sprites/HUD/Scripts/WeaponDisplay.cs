using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDisplay : MonoBehaviour
{
    [HideInInspector] public PlayerMovement PlayerMovement;
    [HideInInspector] public PlayerData Data;

    [Header("Textos")]
    public TMP_Text Quantity;
    public TMP_Text Max;

    [Header("Imagenes")]

    public Image Weapon;
    public Sprite Pistol;
    public Sprite Rifle;
    public Sprite Bazuca;

    void Awake()
    {
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        Quantity.text = "-";
        Max.text = "/INF";

        sort();
    }

    public void sort()
    {
        switch (PlayerMovement.WeaponEquip)
        {
            case 0:
                Weapon.sprite = Pistol;
                Quantity.text = "-";
                Max.text = "/INF";
                break;
            case 1:
                Weapon.sprite = Rifle;
                Quantity.text = "-";
                Max.text = "/INF";
                break;
            case 3:
                Weapon.sprite = Bazuca;
                Quantity.text = "" + Data.bazucaAmmo;
                Max.text = "/" + (Data.bazucaMaxAmmo);
                break;
        }
    }



}
