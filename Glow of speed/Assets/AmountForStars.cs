using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountForStars : MonoBehaviour
{
    public Image Star1;
    public Image Star2;
    public Image Star3;

    public Color _colorStars;

    public Image Fill1;
    public Image Fill2;
    public Image Fill3;

    public int XP1;
    public int XP2;
    public int XP3;

    public int Requirements_1_Stars;
    public int Requirements_2_Stars;
    public int Requirements_3_Stars;
    private int record;
    public string Loadrecord = "recordinonerace";

    public string SaveLoad = "XP_Arena_Play";

    private int audiostar1 = 0;
    private int audiostar2 = 0;
    private int audiostar3 = 0;

    void Awake()
    {
        Fill1.fillAmount = 0f;
        Fill2.fillAmount = 0f;
        Fill3.fillAmount = 0f; 
        if(Loadrecord == "QTT1")
        {
        PlayerPrefs.SetInt(Loadrecord, 0);
        }
    }
    
    void Update()
    {
        record = PlayerPrefs.GetInt(Loadrecord);

        if(record < Requirements_1_Stars)
        {
         Fill1.fillAmount = (float)((float)record / (float)Requirements_1_Stars);
         Debug.Log("amount = " + (float)(record / Requirements_1_Stars));  
         PlayerPrefs.SetInt(SaveLoad, 0);
        }

        if(record >= Requirements_1_Stars && record < Requirements_2_Stars)
        {
         Star1.color = _colorStars;
         Fill1.fillAmount = 1f;
         Fill2.fillAmount = (float)((float)(record - Requirements_1_Stars) / (float)(Requirements_2_Stars - Requirements_1_Stars));  
         PlayerPrefs.SetInt(SaveLoad, XP1);

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
            PlayerPrefs.SetInt(SaveLoad, XP2);

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
            PlayerPrefs.SetInt(SaveLoad, XP3);

         if(audiostar3 == 0)
         {
           PlayerPrefs.SetInt("audiostar", 1);
           audiostar3++;
         }
        }
    }
}
