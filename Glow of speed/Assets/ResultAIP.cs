using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultAIP : MonoBehaviour
{
    public Text MoneyText;
    public Text DiamondText;
    int money;
    int diamond;
    void Update()
    {
        diamond = PlayerPrefs.GetInt("diamonds");
        money = PlayerPrefs.GetInt("Money");

        DiamondText.text = diamond.ToString("D1");
        MoneyText.text = money.ToString("D1");
    }
}
