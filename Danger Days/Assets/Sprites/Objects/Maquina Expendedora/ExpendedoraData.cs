using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpendedoraData : MonoBehaviour
{

    [HideInInspector] public PlayerData Data;

    [Header("Carbons")]
    public TMP_Text carbonsText;


    [Header("Tabs")]

    public TMP_Text Item1;
    public TMP_Text Item2;
    public TMP_Text Item3;
    public TMP_Text Item4;

    [Header("Objetos")]

    public TMP_Text item1;
    public TMP_Text item2;
    public TMP_Text item3;
    public TMP_Text item4;

    [Header("Precios")]

    public int Xenitio;
    public int Voltageno;
    public int Bazuca;
    public int Bidon;
    public int Pistola;

    void Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();

        Item1.text = "$" + Xenitio;
        item1.text = "Total: $" + Xenitio;
        Item2.text = "$" + Voltageno;
        item2.text = "Total: $" + Voltageno;
        Item3.text = "$" + Bazuca;
        item3.text = "Total: $" + Bazuca;
        Item4.text = "$" + Bidon;
        item4.text = "Total: $" + Bidon;
    }

    void Update()
    {
        carbonsText.text = "$" + Data.Carbons;
    }

    public void buyXenitio()
    {
        if (Data.Carbons >= Xenitio && Data.Xenitio < Data.maxXenitio)
        {
            Data.Carbons -= Xenitio;
            Data.Xenitio += 1;
        }

    }
    public void buyVoltageno()
    {
        if (Data.Carbons >= Voltageno && Data.Voltageno < Data.maxVoltageno)
        {
            Data.Carbons -= Voltageno;
            Data.Voltageno += 1;
        }

    }
    public void buyBazuca()
    {
        if (Data.Carbons >= Bazuca && Data.bazucaAmmo < Data.bazucaMaxAmmo)
        {
            Data.Carbons -= Bazuca;
            Data.bazucaAmmo = Data.bazucaMaxAmmo;
        }

    }
    public void buyBidon()
    {
        if (Data.Carbons >= Bidon)
        {
            Data.Carbons -= Bidon;
        }
    }
    public void buyPistola()
    {
        if (Data.Carbons >= Pistola)
        {
            Data.Carbons -= Pistola;
        }
    }





}
