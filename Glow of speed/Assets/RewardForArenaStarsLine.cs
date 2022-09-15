using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardForArenaStarsLine : MonoBehaviour
{
    public Image Star1;
    public Image Star2;
    public Image Star3;

    public Color _colorStars;

    public Image Fill1;
    public Image Fill2;
    public Image Fill3;
    public int Requirements_1_Stars;
    public int Requirements_2_Stars;
    public int Requirements_3_Stars;
    private int record = 0;
    public string flash;
    private int reward;
    private double speed;

    private int ProgresXPLevelClient;
    public string ProgresXPLevelClient_text = "ProgresXPLevelClient";
    private int XP;
    public string XPLoad_Save = "XP_Arena_Play";

    private int audiostar1 = 0;
    private int audiostar2 = 0;
    private int audiostar3 = 0;

    void Start()
    {
            ProgresXPLevelClient = PlayerPrefs.GetInt(ProgresXPLevelClient_text);
            XP = PlayerPrefs.GetInt(XPLoad_Save);
            ProgresXPLevelClient = ProgresXPLevelClient + XP;
            Debug.Log("ProgresXPLevelClient = " + ProgresXPLevelClient);
            PlayerPrefs.SetInt(ProgresXPLevelClient_text, ProgresXPLevelClient);
    }

    void Update()
    {
        reward = PlayerPrefs.GetInt(flash);
        if (reward == 1)
        {
            reward = PlayerPrefs.GetInt(flash);
            Debug.Log("reward == 1");
        }
        else
        {
            Debug.Log("reward = " + reward);
            StartCoroutine(TimeFlow());
        }


        //record = PlayerPrefs.GetInt("recordinonerace");

        if(record < Requirements_1_Stars)
        {
         Fill1.fillAmount = (float)((float)record / (float)Requirements_1_Stars);
         Debug.Log("amount = " + (float)(record / Requirements_1_Stars));  
        }

        if(record >= Requirements_1_Stars && record < Requirements_2_Stars)
        {
         Star1.color = _colorStars;
         Fill1.fillAmount = 1f;
         Fill2.fillAmount = (float)((float)(record - Requirements_1_Stars) / (float)(Requirements_2_Stars - Requirements_1_Stars));  
         if(audiostar1 == 0)
         {
           PlayerPrefs.SetInt("audiostar", 1);
           audiostar1++;
         }
        }

        if(record >= Requirements_2_Stars && record < Requirements_3_Stars)
        {
            Star1.color = _colorStars;
            Star2.color = _colorStars;
            Fill1.fillAmount = 1f;
            Fill2.fillAmount = 1f;
            Fill3.fillAmount = (float)((float)(record - Requirements_2_Stars) / (float)(Requirements_3_Stars - Requirements_2_Stars)); 
            if(audiostar2 == 0)
         {
           PlayerPrefs.SetInt("audiostar", 1);
           audiostar2++;
         }
        }

        if(record >= Requirements_3_Stars)
        {
            Star1.color = _colorStars;
            Star2.color = _colorStars;
            Star3.color = _colorStars;
            Fill1.fillAmount = 1f;
            Fill2.fillAmount = 1f;
            Fill3.fillAmount = 1f; 
            if(audiostar3 == 0)
         {
           PlayerPrefs.SetInt("audiostar", 1);
           audiostar3++;
         }
        }
    }

    IEnumerator TimeFlow()
    {
        speed = reward / 0.5 * 0.001;
        speed = 1 / speed * 2.5; 
        Debug.Log("speed = " + speed);
        while (record != reward)
        {
            if (record != reward)
            {
              record++;
              yield return new WaitForSeconds((float)speed);
            }
        }
    }
}
