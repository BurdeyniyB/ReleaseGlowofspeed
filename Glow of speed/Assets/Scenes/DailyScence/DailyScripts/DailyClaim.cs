using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyClaim : MonoBehaviour
{
    public int coin;
    public GameObject Button;
    [SerializeField] private string localDayInRowKey;
    public int number;
    int money;
    private Text moneytext;
    private Text text;
    public Image _imagePanel;
    public Color _colorStart;
    public Color _color;
    public string SaveText = "Earneg";
    public string SaveMoneyText = "Money";
    private int sound;

    int Earneg;
    void Start()
    {
        _imagePanel.color = _colorStart;
        
        text = GameObject.Find("DailyMessageText").GetComponent<Text>();
        money = PlayerPrefs.GetInt(SaveMoneyText);
        moneytext = GameObject.Find("Money").GetComponent<Text>();
        moneytext.text = money.ToString("D1");
        int set = PlayerPrefs.GetInt(localDayInRowKey);
        Debug.Log("localDayInRowKey = " + localDayInRowKey);
        if(number == set)
        {
            Earneg = PlayerPrefs.GetInt(SaveText);
            Debug.Log("Earneg = " + Earneg);
            if (Earneg == 1)
            {
                Button.SetActive(true); 
                _imagePanel.color = _color;
                Debug.Log("Earneg");
                PlayerPrefs.SetInt("SaveDailyClaim", 1);
                text.text = "Day In Row -> " + number.ToString("D1");
            }
            else
            {
             int save = PlayerPrefs.GetInt("SaveDailyClaim");
                if (save == 1)
                {
                Button.SetActive(true); 
                _imagePanel.color = _color;
                Debug.Log("Earneg");
                text.text = "Day In Row -> " + number.ToString("D1");
                }
                else
                {
                  Button.SetActive(false); 
                  Debug.Log("Earnegfalse");
                }
            }
        }
        else
        {
          Button.SetActive(false); 
          Debug.Log("false");
        }
    }

    void Update()
    {
       sound = PlayerPrefs.GetInt("SettingSound");
       Earneg = PlayerPrefs.GetInt(SaveText);
       int set = PlayerPrefs.GetInt(localDayInRowKey);
       if(number == set)
        {
            Earneg = PlayerPrefs.GetInt(SaveText);
            if (Earneg == 1)
            {
                Button.SetActive(true); 
                text.text = "Day In Row -> " + number.ToString("D1");
            }
            else
            {
                Button.SetActive(false); 
            }
        }
        else
        {
          Button.SetActive(false); 
        }
    }
    public void SetCoin()
    {  
               if(sound == 1)
               {
                 Debug.Log("ClickDR");
                 PlayerPrefs.SetInt("ClickDR", 1);
               }
            money = money + coin;
            PlayerPrefs.SetInt(SaveMoneyText, money);
            moneytext.text = money.ToString("D1");
            Button.SetActive(false); 
            int Earneg = 0;
            PlayerPrefs.SetInt(SaveText, Earneg);
            PlayerPrefs.SetInt("SaveDailyClaim", 0);
            text.text = "Reward Earned Today ";
    }
}
