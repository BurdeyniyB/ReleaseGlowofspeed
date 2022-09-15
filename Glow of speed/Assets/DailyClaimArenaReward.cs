using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DailyClaimArenaReward : MonoBehaviour
{
    public int coin;
    public GameObject Button;
    public GameObject Image;
    [SerializeField] private string localDayInRowKey;
    int money;
    private Text moneytext;
    private Text text;
    public Image _imagePanel;
    public Color _colorStart;
    public Color _color;
    public string SaveText = "Earneg";
    public string SaveMoneyText = "Money";
    public string ScoreText;

    public int min;
    public int max;

    int Earneg;
    int score;
    private int sound;
    void Start()
    {
        _imagePanel.color = _colorStart;

        money = PlayerPrefs.GetInt(SaveMoneyText);
        int set = PlayerPrefs.GetInt(localDayInRowKey);
        Debug.Log("localDayInRowKey = " + localDayInRowKey);     

        score = PlayerPrefs.GetInt(ScoreText);

        if(score <= max && score >= min)
        {
            Earneg = PlayerPrefs.GetInt(SaveText);
            Debug.Log("Earneg = " + Earneg);
            if (Earneg == 1)
            {
                Button.SetActive(true); 
                Image.SetActive(true); 
                _imagePanel.color = _color;
                Debug.Log("Earneg");
                PlayerPrefs.SetInt("SaveDailyClaimArenaReward", 1);
            }
            else
            {
             int save = PlayerPrefs.GetInt("SaveDailyClaimArenaReward");
                if (save == 1)
                {
                Button.SetActive(true); 
                Image.SetActive(true);
                _imagePanel.color = _color;
                Debug.Log("Earneg");

                }
                else
                {
                  Button.SetActive(false); 
                  Image.SetActive(false);
                  Debug.Log("Earnegfalse");
                }
            }
        }
		else
		{
			Button.SetActive(false); 
            Image.SetActive(false);
            Debug.Log("record false");
		} 
            
    }

    void Update()
    {
       sound = PlayerPrefs.GetInt("SettingSound");
       Earneg = PlayerPrefs.GetInt(SaveText);
       int set = PlayerPrefs.GetInt(localDayInRowKey);      
            Earneg = PlayerPrefs.GetInt(SaveText);
            if (Earneg == 1)
            {
                Button.SetActive(true); 
            }
            else
            {
                Button.SetActive(false); 
            }

            if(score <= max && score >= min)
        {
            Earneg = PlayerPrefs.GetInt(SaveText);
            Debug.Log("Earneg = " + Earneg);
            if (Earneg == 1)
            {
                Button.SetActive(true); 
                Image.SetActive(true);
                _imagePanel.color = _color;
                Debug.Log("Earneg");
                PlayerPrefs.SetInt("SaveDailyClaimArenaReward", 1);
            }
            else
            {
             int save = PlayerPrefs.GetInt("SaveDailyClaimArenaReward");
                if (save == 1)
                {
                Button.SetActive(true); 
                Image.SetActive(true);
                _imagePanel.color = _color;
                Debug.Log("Earneg");

                }
                else
                {
                  Button.SetActive(false); 
                  Image.SetActive(false);
                  Debug.Log("Earnegfalse");
                }
            }
        }
		else
		{
			Button.SetActive(false); 
            Image.SetActive(false);
            Debug.Log("record false");
		} 
            
    }
    public void SetCoin()
    {
            if(sound == 1)
               {
                 Debug.Log("ClickLB");
                 PlayerPrefs.SetInt("ClickLB", 1);
               }
            _imagePanel.color = _colorStart;
            money = money + coin;
            PlayerPrefs.SetInt(SaveMoneyText, money);
            Button.SetActive(false); 
            Image.SetActive(false);
            int Earneg = 0;
            PlayerPrefs.SetInt(SaveText, Earneg);
            Debug.Log("PlayerPrefs.SetInt(SaveText, Earneg);");
            PlayerPrefs.SetInt("SaveDailyClaimArenaReward", 0);
    }
}
