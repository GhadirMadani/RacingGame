using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Import TextMeshPro namespace

public class GlobalCash : MonoBehaviour
{
    public int CashValue;
    public static int TotalCash;
    public TextMeshProUGUI CashDisplay;  // Use TMP instead of GameObject

    void Update()
    {
        CashValue = TotalCash;
        CashDisplay.text = "Cash $" + CashValue;
    }
}
