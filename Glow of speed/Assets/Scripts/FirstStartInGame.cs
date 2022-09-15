using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStartInGame : MonoBehaviour
{
    public int Manager;
    private string Save = "FirstStartInGame";
    public GameObject Panel;
    public InputField Name;
    public Text name;
    public GameObject Button;
    public GameObject ButtonField;
    public GameObject[] BlockPanel;
    public SkinManager skinManager;
    public GameObject KrugerPanel;
    public GameObject KrugerMassege;
    public GameObject KrugerMassege1;
    public GameObject Clicker;
    public GameObject Clicker1;
    public GameObject Clicker2;
    public GameObject panelPlay;
    private int Clientlvl;

    void Start()
    {
      Clientlvl = PlayerPrefs.GetInt("LvlClient");
      name.text = PlayerPrefs.GetString("GameName");
      Debug.Log("name.text = " + name.text);
      if(Clientlvl < 5)
      {
      Manager = PlayerPrefs.GetInt("FirstStartInGame");
      if(Manager == 0)
      {
        skinManager.Unlock(0);
        skinManager.SelectSkin(0);
        if(name.text == "")
        {
          panelPlay.SetActive(true);
          kruger();
        }
        PlayerPrefs.SetInt("FirstStartInGame", 1);
        PlayerPrefs.SetInt("SettingSound", 1);
        PlayerPrefs.SetInt("SettingMusic", 1);
        PlayerPrefs.SetInt("SettingVibration", 1);

        for(int i = 0; i < BlockPanel.Length; i++)
        {
        BlockPanel[i].SetActive(true);
        }
      }
      }

      if(Clientlvl == 20)
      {
      Manager = PlayerPrefs.GetInt("FirstStartInGame20lvl");
      if(Manager == 0)
      {
        Clicker1.SetActive(true);
        PlayerPrefs.SetInt("FirstStartInGame20lvl", 1);
      }
      }

      if(Clientlvl == 30)
      {
      Manager = PlayerPrefs.GetInt("FirstStartInGame30lvl");
      if(Manager == 0)
      {
        Clicker2.SetActive(true);
        PlayerPrefs.SetInt("FirstStartInGame30lvl", 1);
      }
      }
       
    }
    void Update()
    {
       name.text = PlayerPrefs.GetString("GameName"); 
    }
    public void OnName(string field)
    {
        name.text = Name.text;
        Debug.Log(name);
        if(name.text != "")
        {
           ButtonField.SetActive(true);
           Button.SetActive(false);
           PlayerPrefs.SetString("GameName", name.text);
        }
    }
    public void ButtonFieldvoid()
    {
        Panel.SetActive(false);
    }

    public void kruger()
    {
      KrugerPanel.SetActive(true);
      KrugerMassege.SetActive(true);
    }
        public void kruger1()
    {
      KrugerPanel.SetActive(false);
      KrugerMassege.SetActive(false);
      Panel.SetActive(true);
      GetComponent<AudioSource>().Play();
    }

    public void kruger2()
    {
      KrugerPanel.SetActive(true);
      KrugerMassege1.SetActive(true);
      GetComponent<AudioSource>().Play();
    }

        public void kruger3()
    {
      KrugerPanel.SetActive(false);
      KrugerMassege1.SetActive(false);
      Clicker.SetActive(true);
      GetComponent<AudioSource>().Play();
    }
}
