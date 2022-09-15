using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeelGold : MonoBehaviour
{
   [SerializeField] private GameObject button ;
   [SerializeField] private GameObject buttonBuy ;
   [SerializeField] private GameObject Panel;
   [SerializeField] private GameObject Closebutton;
   public int diamonds;
   public int Ads;
   public int Adswacht;
   public int GoldTicket;
   public int cost;

   public Text diamonds_text;
   public Text Ads_text;
   public Text GoldTicket_text;

    void Update()
    {
        diamonds = PlayerPrefs.GetInt("diamonds");
        diamonds_text.text = diamonds.ToString("D1");
        Ads = PlayerPrefs.GetInt("ADScoin");
        Ads_text.text = Ads.ToString("D1");
        GoldTicket = PlayerPrefs.GetInt("GoldTicket");
        GoldTicket_text.text = GoldTicket.ToString("D1");
    }

    public void OpenPanel()
    {
        Panel.SetActive(true);
        Closebutton.SetActive(true);
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
        Closebutton.SetActive(false);
    }

    public void AdsClaim()
    {
        Adswacht = PlayerPrefs.GetInt("ADSwath");
        Adswacht++;
        PlayerPrefs.SetInt("ADSwath", Adswacht);
        Debug.Log("ADSwath = " + Adswacht);
        Ads = PlayerPrefs.GetInt("ADScoin");
        Ads++;
        PlayerPrefs.SetInt("ADScoin", Ads);
        Debug.Log("ADScoin = " + Ads);
    }



    public void BuyGoldTicket()
    {
        if(cost <= diamonds)
        {
        diamonds -= cost;
        GoldTicket += 1;
        PlayerPrefs.SetInt("diamonds", diamonds);
        PlayerPrefs.SetInt("GoldTicket", GoldTicket);
        PlayerPrefs.SetInt("BuyInStore", 1);
        }
    }


    public void ADSBuyGoldTicket()
    {
        if(cost <= Ads)
        {
        Ads -= cost;
        GoldTicket += 1;
        PlayerPrefs.SetInt("Adscoin", Ads);
        PlayerPrefs.SetInt("GoldTicket", GoldTicket);
        PlayerPrefs.SetInt("BuyInStore", 1);
        }
    }


    public void WeelSpeenGold()
    {
        if(1 <= GoldTicket)
        {
        GoldTicket -= 1;
        PlayerPrefs.SetInt("GoldTicket", GoldTicket);
        PlayerPrefs.SetInt("BuyInStore", 1);
        button.SetActive(true);
        buttonBuy.SetActive(false);
        }
    }
}
