using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WIN : MonoBehaviour
{

    public PlayerData Data;
    [SerializeField] TMP_Text Score;
    [SerializeField] TMP_Text Carbons;

    void Start()
    {
        Data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
    }

    void Update()
    {
        Score.text = (Data.Score).ToString();
        Carbons.text = (Data.Carbons).ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Nivel1()
    {
        SceneManager.LoadScene(1);
    }
    public void Nivel2()
    {
        SceneManager.LoadScene(2);
    }
    public void Nivel3()
    {
        SceneManager.LoadScene(3);
    }
    public void Nivel4()
    {
        SceneManager.LoadScene(4);
    }
    public void Nivel5()
    {
        SceneManager.LoadScene(5);
    }
    public void Nivel6()
    {
        SceneManager.LoadScene(6);
    }
    public void Nivel7()
    {
        SceneManager.LoadScene(7);
    }
    public void Nivel8()
    {
        SceneManager.LoadScene(8);
    }
}
