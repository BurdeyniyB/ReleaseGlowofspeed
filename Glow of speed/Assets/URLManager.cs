using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

public class URLManager : MonoBehaviour
{
    public struct userAttributes { };
    public struct appAttributes { };
    private string my_url;


    void Update()
    {
          ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
          Debug.Log("App URL" + ConfigManager.appConfig.GetString("ApplicationURL"));
          my_url = ConfigManager.appConfig.GetString("ApplicationURL");
          Debug.Log("App URL" + my_url);
    }
   
    public void url()
    {
        Application.OpenURL(my_url);
    }

    public void ApplicationURL()
    {
        Application.OpenURL(ConfigManager.appConfig.GetString("ApplicationURL"));
    }
}
