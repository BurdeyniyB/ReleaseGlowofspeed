using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateDailyQuest : MonoBehaviour
{
    public Text Task;
    public string tasktextpart1;
    public string tasktextpart2;
    public int reward;
    public Text _rewardtext;
    public Text _result;

    //coinsforonerace;
    //recordinonerace;

    private int rewardint;
    public GameObject Button;
    private int ActiveFunctoin = 0;
    public int setcoin;
    private int LoadCoin;
    public string setcoinLoadstring;
    public string ActiveFunctoinSave;
    public string rewardsave;
    public string CompleteTaskString;
    private int CompleteTask;

    public Image ColorPanelReward;
    public Color _colorClick;

    private int sound;
    public bool UpdateQuestlvl;
    public float[] coefUpdatelvl;
    private float absoluteCoefUpdatelvl;

    void Awake()
    {
       if(UpdateQuestlvl)
        {
            UpdateQuestLvlVoid();
        }
    }
    void Update()
    {
        sound = PlayerPrefs.GetInt("SettingSound");
        CompleteTask = PlayerPrefs.GetInt(CompleteTaskString);
        LoadCoin = PlayerPrefs.GetInt(setcoinLoadstring);
        Debug.Log("Set reward " + setcoinLoadstring + " length - " + LoadCoin);
        _rewardtext.text = setcoin.ToString("D1");
        rewardint = PlayerPrefs.GetInt(rewardsave);
        Task.text = tasktextpart1 + " " + reward.ToString("D1") + " " + tasktextpart2;

        if(rewardint > reward)
        {
            rewardint = reward;
        }

        if (CompleteTask == 0)
        {
            _result.text = rewardint + " / " + reward;
        }
        else
        {
            _result.text = "Comlete task";
        }

          ActiveFunctoin = PlayerPrefs.GetInt(ActiveFunctoinSave);
          if (ActiveFunctoin == 1)
          {
             Button.SetActive(true);
          }
        else
          {
          if (rewardint >= reward)
          {
             if(CompleteTask == 0)
            {
             rewardint = reward;
             Button.SetActive(true);
             ActiveFunctoin = 1;
             PlayerPrefs.SetInt(ActiveFunctoinSave, ActiveFunctoin);
            }
          }
          else
          {

             Button.SetActive(false);
          }
          }

          if(CompleteTask == 1)
          {
              ColorPanelReward.color = _colorClick;
          }
    }

    public void UpdateQuestLvlVoid()
    {
     int my_lvl =  PlayerPrefs.GetInt("LvlClient");
    
     absoluteCoefUpdatelvl = coefUpdatelvl[0];
     for(int i = 1; i <= my_lvl; i++)
     {
       if(i <= 20)
      {
       absoluteCoefUpdatelvl = (float)(absoluteCoefUpdatelvl * coefUpdatelvl[0]);
       Debug.Log("absoluteCoefUpdatelvl = " + absoluteCoefUpdatelvl);
      }
     }
      reward = (int)(reward * absoluteCoefUpdatelvl);
      Debug.Log("reward = " + reward);

     //lvl 20+
     if(my_lvl > 20)
    {
     absoluteCoefUpdatelvl = coefUpdatelvl[1];
     for(int i = 21; i <= my_lvl; i++)
     {
        if(i <= 40)
      {
       absoluteCoefUpdatelvl = (float)(absoluteCoefUpdatelvl * coefUpdatelvl[1]);
       Debug.Log("absoluteCoefUpdatelvl = " + absoluteCoefUpdatelvl);
      }
     }
      reward = (int)(reward * absoluteCoefUpdatelvl);
      Debug.Log("reward 20+ = " + reward);
    }

     //lvl 40+
     if(my_lvl > 40)
    {
     absoluteCoefUpdatelvl = coefUpdatelvl[2];
     for(int i = 41; i <= my_lvl; i++)
     {
        if(i <= 60)
      {
       absoluteCoefUpdatelvl = (float)(absoluteCoefUpdatelvl * coefUpdatelvl[2]);
       Debug.Log("absoluteCoefUpdatelvl = " + absoluteCoefUpdatelvl);
      }
     }
      reward = (int)(reward * absoluteCoefUpdatelvl);
      Debug.Log("reward 40+ = " + reward);
    }


     //lvl 60+
     if(my_lvl > 60)
    {
     absoluteCoefUpdatelvl = coefUpdatelvl[3];
     for(int i = 61; i <= my_lvl; i++)
     {
        if(i <= 80)
      {
       absoluteCoefUpdatelvl = (float)(absoluteCoefUpdatelvl * coefUpdatelvl[3]);
       Debug.Log("absoluteCoefUpdatelvl = " + absoluteCoefUpdatelvl);
      }
     }
      reward = (int)(reward * absoluteCoefUpdatelvl);
      Debug.Log("reward 60+ = " + reward);
    }


     //lvl 80+
     if(my_lvl > 80)
    {
     absoluteCoefUpdatelvl = coefUpdatelvl[4];
     for(int i = 81; i <= my_lvl; i++)
     {
        if(i <= 100)
      {
       absoluteCoefUpdatelvl = (float)(absoluteCoefUpdatelvl * coefUpdatelvl[4]);
       Debug.Log("absoluteCoefUpdatelvl = " + absoluteCoefUpdatelvl);
      }
     }
      reward = (int)(reward * absoluteCoefUpdatelvl);
      Debug.Log("reward 80+ = " + reward);
    }

    }


    public void NewDayVoid(int i)
    {
        PlayerPrefs.SetInt(rewardsave, 0);
        Debug.Log("New Day task " + i);

        rewardint = PlayerPrefs.GetInt(rewardsave);
        Task.text = tasktextpart1 + " " + reward.ToString("D1") + " " + tasktextpart2;
        if(rewardint > reward)
        {
            rewardint = reward;
        }
        _result.text = rewardint + " / " + reward;

        ActiveFunctoin = 0;
        PlayerPrefs.SetInt(ActiveFunctoinSave, 0);
        Button.SetActive(false);

        ActiveFunctoin = 0;
        PlayerPrefs.SetInt(ActiveFunctoinSave, ActiveFunctoin);

        CompleteTask = 0;
        PlayerPrefs.SetInt(CompleteTaskString, CompleteTask);
    }

    public void ButtonClaim()
    {
          Button.SetActive(false);
          if(sound == 1)
               {
                   Debug.Log("ClickUDQ");
                 PlayerPrefs.SetInt("ClickUDQ", 1);
               }
          LoadCoin = LoadCoin + setcoin;
          Debug.Log("Get reward " + setcoinLoadstring + " length - " + LoadCoin);
          PlayerPrefs.SetInt(setcoinLoadstring, LoadCoin);

          PlayerPrefs.SetInt(rewardsave, 0);
          rewardint = PlayerPrefs.GetInt(rewardsave);
          _result.text = rewardint + " / " + reward;

          CompleteTask = 1;
          PlayerPrefs.SetInt(CompleteTaskString, CompleteTask);

          ActiveFunctoin = 0;
          PlayerPrefs.SetInt(ActiveFunctoinSave, ActiveFunctoin);
         int ClickForpadate = PlayerPrefs.GetInt("ClickForpadate");
         ClickForpadate++;
         PlayerPrefs.SetInt("ClickForpadate", ClickForpadate);
    }
}
