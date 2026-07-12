using System.Collections;
using UnityEngine;

public class PaymentOperationScript : MonoBehaviour
{
    [SerializeField] uint cashToAdd = 0;
    [SerializeField] GameObject paymentInProcessWindow;
    [SerializeField] SpawnAnimMoney spawnAnimMoneyGO;

    [SerializeField] PlaySoundOneSource sound;

    public void OnBuyButtonClick()
    {
        paymentInProcessWindow.SetActive(true);
        StartCoroutine("Timer");
    }
    IEnumerator Timer()
    {
        for (int i = 2; i >= 0; i--)
        {
            yield return new WaitForSeconds(1.0f);
        }
        CashScript.Add(cashToAdd);
        spawnAnimMoneyGO.Spawn();
        paymentInProcessWindow.SetActive(false);
        if (sound != null)
        {
            sound.PlaySound();
        }
    }
}
