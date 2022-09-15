using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardForArena : MonoBehaviour
{
    public string flash;
    public Text text;
    private int reward;
    private int sum = 0;
    private double speed;

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
    }

    IEnumerator TimeFlow()
    {
        speed = reward / 0.5 * 0.001;
        speed = 1 / speed * 2.5; 
        Debug.Log("speed = " + speed);
        while (sum != reward)
        {
            if (sum != reward)
            {
              sum++;

              text.text = sum.ToString("D1");
              yield return new WaitForSeconds((float)speed);
            }
        }
    }
}
