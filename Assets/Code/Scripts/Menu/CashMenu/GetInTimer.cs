using System.Collections;
using TMPro;
using UnityEngine;

public class GetInTimer : MonoBehaviour
{
    [SerializeField] uint moneyToAdd;
    [SerializeField] uint secondsToWait;
    [SerializeField] TMP_Text textToChange;
    private bool isReady = true;
    [SerializeField] SpawnAnimMoney spawnAnimMoneyGO;

    [SerializeField] PlaySoundOneSource sound;

    void Start()
    {
        isReady = false;
        StartCoroutine("Timer");
    }

    public void OnGetMoneyTimerButtonClick()
    {
        if (isReady) {
            
            isReady = false;
            CashScript.Add(moneyToAdd);

            if (sound != null)
            {
                sound.PlaySound();
            }

            spawnAnimMoneyGO.Spawn();
            StartCoroutine("Timer");
        }
    }

    IEnumerator Timer()
    {
        for (uint i = secondsToWait; i != 0; i--)
        {
            textToChange.text = "00:"+i.ToString();
            yield return new WaitForSeconds(1.0f);
        }

        textToChange.text = "00:00";
        isReady = true;
    }
}
