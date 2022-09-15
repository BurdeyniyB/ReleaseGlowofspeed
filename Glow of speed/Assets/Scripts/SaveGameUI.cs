using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameUI : MonoBehaviour
{
    public string name;
    public int age;
    public Text logTxt;
    public Text outputTxt;
    public InputField nameInputField;
    public InputField ageInputField;

    public void OnName(string field)
    {
        name = nameInputField.text;
    }

    public void OnAge(string field)
    {
        age = int.Parse(ageInputField.text);
    }
}
