using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPRewardPanel : MonoBehaviour
{
    public GameObject[] XPPanel;
    void Start()
    {
        
    }
 
    public void ActivePanel(int number)
    {
        XPPanel[number].SetActive(true);
    }

    public void FalseActivePanel(int number)
    {
        XPPanel[number].SetActive(false);
    }
}
