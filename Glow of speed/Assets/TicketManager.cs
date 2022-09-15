using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketManager : MonoBehaviour
{
    public Text Tickets;
    private int _tickets;

    void Update()
    {
        _tickets = PlayerPrefs.GetInt("Ticket");
        Tickets.text = _tickets.ToString("D1");
    }
}
