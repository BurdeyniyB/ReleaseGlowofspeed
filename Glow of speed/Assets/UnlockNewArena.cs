using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockNewArena : MonoBehaviour
{
    public GameObject ArenaButton;
    public GameObject ArenaLockImage;
    public int Needrecord;
    private int record;
    public string recordtext;
    void Start()
    {
        record = PlayerPrefs.GetInt(recordtext);
        if(Needrecord <= record)
        {
            ArenaButton.SetActive(true);
            ArenaLockImage.SetActive(false);
        }
        else
        {
            ArenaButton.SetActive(false);
            ArenaLockImage.SetActive(true);
        }
    }

}
