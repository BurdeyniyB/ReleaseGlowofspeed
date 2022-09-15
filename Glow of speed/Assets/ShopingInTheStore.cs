using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopingInTheStore : MonoBehaviour
{
    public int Claim;
    public int Cost;
    public Text ClaimText;
    public Text CostText;
    public string ClaimSave;
    public string CostSave;
    private int LoadCurrencyClaim;
    private int LoadCurrencyCost;
    void Update()
    { 
        LoadCurrencyClaim = PlayerPrefs.GetInt(ClaimSave);
        LoadCurrencyCost = PlayerPrefs.GetInt(CostSave);
    }

    public void Shoping()
    {
        if(LoadCurrencyCost >= Cost)
        {
            LoadCurrencyClaim = LoadCurrencyClaim + Claim;
            LoadCurrencyCost = LoadCurrencyCost - Cost;
            
            PlayerPrefs.SetInt(ClaimSave, LoadCurrencyClaim);
            PlayerPrefs.SetInt(CostSave, LoadCurrencyCost);
            PlayerPrefs.SetInt("BuyInStore", 1);
            ClaimText.text = LoadCurrencyClaim.ToString("D1");  
            CostText.text = LoadCurrencyCost.ToString("D1"); 
        }
    }
}
