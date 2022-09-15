using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPClaimShoping : MonoBehaviour
{
    public void OnPurchaseCompleted(Product product)
    {
        switch(product.definition.id)
        {
            case "com.kantep.gabyhell.50diamonds":
              Add50diamonds();
            break;

            case "com.kantep.gabyhell.100diamonds":
              Add100diamonds();
            break;

            case "com.kantep.gabyhell.250diamonds":
              Add250diamonds();
            break;

            case "com.kantep.gabyhell.500diamonds":
              Add500diamonds();
            break;

            case "com.kantep.gabyhell.2000diamonds":
              Add2000diamonds();
            break;

            case "com.kantep.gabyhell.5000diamonds":
              Add5000diamonds();
            break;
        }
    } 

    private void Add50diamonds()
    {
        int diamonds = PlayerPrefs.GetInt("diamonds");
        diamonds += 50;
        Debug.Log("Add50diamonds = " + diamonds);
        PlayerPrefs.SetInt("diamonds", diamonds);
    }

    private void Add100diamonds()
    {
        int diamonds = PlayerPrefs.GetInt("diamonds");
        diamonds += 100;
        Debug.Log("Add50diamonds = " + diamonds);
        PlayerPrefs.SetInt("diamonds", diamonds);
    }

    private void Add250diamonds()
    {
        int diamonds = PlayerPrefs.GetInt("diamonds");
        diamonds += 250;
        Debug.Log("Add50diamonds = " + diamonds);
        PlayerPrefs.SetInt("diamonds", diamonds);
    }

    private void Add500diamonds()
    {
        int diamonds = PlayerPrefs.GetInt("diamonds");
        diamonds += 500;
        Debug.Log("Add50diamonds = " + diamonds);
        PlayerPrefs.SetInt("diamonds", diamonds);
    }
    private void Add2000diamonds()
    {
        int diamonds = PlayerPrefs.GetInt("diamonds");
        diamonds += 2000;
        Debug.Log("Add50diamonds = " + diamonds);
        PlayerPrefs.SetInt("diamonds", diamonds);
    }

    private void Add5000diamonds()
    {
        int diamonds = PlayerPrefs.GetInt("diamonds");
        diamonds += 5000;
        Debug.Log("Add50diamonds = " + diamonds);
        PlayerPrefs.SetInt("diamonds", diamonds);
    }
}
