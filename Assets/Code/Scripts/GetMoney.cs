using UnityEngine;

public class GetMoney : MonoBehaviour
{
    [SerializeField] protected uint addMoneyVal;
    [SerializeField] protected SpawnAnimMoney spawnAnimMoneyScript;

    [SerializeField] PlaySoundOneSource sound;
    public void AddMoney()
    {

        CashScript.Add(addMoneyVal);

        if (sound != null)
        {
            sound.PlaySound();
        }

        spawnAnimMoneyScript.Spawn();
    }
}
