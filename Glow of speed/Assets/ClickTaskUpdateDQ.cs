using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTaskUpdateDQ : MonoBehaviour
{
    public GameObject[] PanelReward;
    public Image[] ColorPanelReward;
    public Color _colorClick;
    public Color _colorStandart;
    private int sound;

    void Update()
    {
       sound = PlayerPrefs.GetInt("SettingSound");
    }
    public void ClidkOnTask(int num)
    {
       for (int i = 0; i < PanelReward.Length; i++)
       {
           if(i == (num - 1))
           {
               PanelReward[i].SetActive(true);
               ColorPanelReward[i].color = _colorClick;
               if(sound == 1)
               {
                 GetComponent<AudioSource>().Play();
               }
           }

           if(i != (num - 1))
           {
               PanelReward[i].SetActive(false);
               ColorPanelReward[i].color = _colorStandart;
           }
       }
    }

    public void ClidkClose()
    {
       for (int i = 0; i < PanelReward.Length; i++)
       {
               PanelReward[i].SetActive(false);
               ColorPanelReward[i].color = _colorStandart;
       }
    }
    
}
