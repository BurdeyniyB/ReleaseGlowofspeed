using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyQuest : MonoBehaviour
{
    private Text Quest;
    private Text Task;
    private Text Set;
    private Text Resive;
    public string questext;
    public string tasktext;
    public string tasktextpart1;
    public string tasktextpart2;
    public int reward;
    private int coinsforonerace;
    private int recordinonerace;
    private int rewardint;
    public Image bar;
    private float fill;
    public GameObject Button;
    private int ActiveFunctoin = 0;
    private int money;
    public int setcoin;
    public string setcointext;
    private Text moneytext;
    public string ActiveFunctoinSave;
    public string rewardsave;
    public string resivetext;

    void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        moneytext = GameObject.Find("Money").GetComponent<Text>();
        moneytext.text = money.ToString("D1");
        
        Resive = GameObject.Find(resivetext).GetComponent<Text>();
        Resive.text = "/ " + reward.ToString("D1");
        Set = GameObject.Find(setcointext).GetComponent<Text>();
        Set.text = setcoin.ToString("D1");
        Task = GameObject.Find(tasktext).GetComponent<Text>();
        Task.text = tasktextpart1 + " " + reward.ToString("D1") + " " + tasktextpart2;
        Quest = GameObject.Find(questext).GetComponent<Text>();
          ActiveFunctoin = PlayerPrefs.GetInt(ActiveFunctoinSave);
          if (ActiveFunctoin == 1)
          {
             Quest.text = reward.ToString("D1") + " ";
             bar.fillAmount = 1;
             Button.SetActive(true);
             Debug.Log("10");
          }
        else
          {
              rewardint = PlayerPrefs.GetInt(rewardsave);
              Debug.Log("11  " + rewardint + rewardsave);
          if (rewardint >= reward)
          {
             rewardint = reward;
             Quest.text = rewardint.ToString("D1") + " ";
             fill =  rewardint / reward;
             Debug.Log("fill = " + fill);
             double fillmanager = rewardint / reward;
             bar.fillAmount = (float)fillmanager;
             Debug.Log("fillmanager = " + (float)fillmanager);
             Button.SetActive(true);
             ActiveFunctoin = 1;
             PlayerPrefs.SetInt(ActiveFunctoinSave, ActiveFunctoin);
             Debug.Log("11");
          }
          else
          {
             Quest.text = rewardint.ToString("D1") + " ";
             Button.SetActive(false);
             fill = rewardint / reward;
             Debug.Log("fill = " + fill);
             double fillmanager =  rewardint / reward;
             Debug.Log("fillmanager = " + (float)fillmanager);
             Debug.Log(fill);
             bar.fillAmount = (float)fillmanager; 
             Debug.Log("12");
          }
          }
        
        

    }

    public void ButtonClaim()
    {
      Button.SetActive(false);

      money = money + setcoin;
      PlayerPrefs.SetInt("Money", money);
      moneytext.text = money.ToString("D1");

      bar.fillAmount = 0;

          Debug.Log("ButtonClaimRecord");
          PlayerPrefs.SetInt(rewardsave, 0);
          ActiveFunctoin = 0;
          PlayerPrefs.SetInt(ActiveFunctoinSave, ActiveFunctoin);
         int ClickForpadate = PlayerPrefs.GetInt("ClickForpadate");
         ClickForpadate++;
         PlayerPrefs.SetInt("ClickForpadate", ClickForpadate);
    }
}
