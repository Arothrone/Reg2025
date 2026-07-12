using System;
using TMPro;
using UnityEngine;

public class CashTextHolder : MonoBehaviour
{
    [SerializeField] TMP_Text cashTextToUpdate;

    void Update()
    {
        
        uint cashNum = CashScript.GetCashValue();
        if (cashNum < 1000) {
            cashTextToUpdate.text = cashNum.ToString();
        } else
        {
            double floored = Math.Floor((cashNum / 1000D)*10)/10;

            cashTextToUpdate.text = floored.ToString()+" k";
        }
    }
}
