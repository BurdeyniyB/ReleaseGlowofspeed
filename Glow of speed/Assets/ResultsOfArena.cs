using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsOfArena : MonoBehaviour
{
    public Text Arena1;
    public Text Arena2;
    public Text Arena3;
    public Text Arena4;
    public Text Arena5;

    public int arena1;
    public int arena2;
    public int arena3;
    public int arena4;
    public int arena5;

    public GameObject Panel;

    void Update()
    {
        arena1 = PlayerPrefs.GetInt("bestrecord");
        arena2 = PlayerPrefs.GetInt("bestrecordarena2");
        arena3 = PlayerPrefs.GetInt("bestrecordarena3");
        arena4 = PlayerPrefs.GetInt("bestrecordarena4");
        arena5 = PlayerPrefs.GetInt("bestrecordarena5");

        Arena1.text = arena1.ToString("D1");
        Arena2.text = arena2.ToString("D1");
        Arena3.text = arena3.ToString("D1");
        Arena4.text = arena4.ToString("D1");
        Arena5.text = arena5.ToString("D1");
    }

    public void OnPressButton()
    {
      Panel.SetActive(true);
    }
  
    public void OffPressButton()
    {
      Panel.SetActive(false);
    }
}
