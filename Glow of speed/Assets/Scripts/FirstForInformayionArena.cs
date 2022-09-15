using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstForInformationArena : MonoBehaviour
{
    private int manager;
    public GameObject Panel;
    void Start()
    {
        manager = PlayerPrefs.GetInt("FirstForInformationArena");
        if(manager == 0)
        {
            Panel.SetActive(true);
        }

        PlayerPrefs.SetInt("FirstForInformationArena", 1);
    }
}
