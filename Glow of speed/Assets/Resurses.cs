using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resurses : MonoBehaviour
{
    public int money;
    public Text money_Text;
    public int diamond;
    public Text diamond_Text;
    public int ticket;
    public Text ticket_Text;
    void Update()
    {
        money = PlayerPrefs.GetInt("Money");
        money_Text.text = money.ToString("D1");
        diamond = PlayerPrefs.GetInt("diamonds");
        diamond_Text.text = diamond.ToString("D1");
        ticket = PlayerPrefs.GetInt("Ticket");
        ticket_Text.text = ticket.ToString("D1");
    }
}
