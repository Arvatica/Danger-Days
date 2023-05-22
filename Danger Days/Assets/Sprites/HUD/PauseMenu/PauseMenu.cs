using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    public PlayerData Data;

    [Header("Llamados")]
    public TMP_Text carbonsText;
    public TMP_Text gasolineText;

    void Start()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
    }

    void Update()
    {
        carbonsText.text = "$" + Data.Carbons;
        gasolineText.text = Data.Gasoline + "/" + Data.GasolineToPickUp;
    }
}
