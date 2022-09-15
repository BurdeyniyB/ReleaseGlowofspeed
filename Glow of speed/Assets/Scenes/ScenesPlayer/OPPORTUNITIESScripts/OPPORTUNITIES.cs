using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPPORTUNITIES : MonoBehaviour
{
    public GameObject PanelOPPORTUNITIES;
    public GameObject Button;
    public GameObject ButtonLock;
    public GameObject ButtonUpdate;
    public int UnLockLvl;
    public string lvlskinstring;

    
    private int lvlSkin;
     

    void Update()
    {
        lvlSkin = PlayerPrefs.GetInt(lvlskinstring);
        Debug.Log(lvlSkin);
    }

    public void Open()
    {
      if (lvlSkin >= UnLockLvl)
        {
            ButtonUpdate.SetActive(true);
            Button.SetActive(true);
            ButtonLock.SetActive(false);
        }
        else
        {
            ButtonUpdate.SetActive(false);
            Button.SetActive(false);
            ButtonLock.SetActive(true);
        }
    }

    public void Click()
    {
        PanelOPPORTUNITIES.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
    public void ClickClose()
    {
        PanelOPPORTUNITIES.SetActive(false);
        GetComponent<AudioSource>().Play();
    }
}
