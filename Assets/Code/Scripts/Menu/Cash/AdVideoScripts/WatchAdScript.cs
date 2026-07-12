using UnityEngine;

public class WatchAdScript : MonoBehaviour
{
    [SerializeField] GameObject adVideoGO;
    //[SerializeField] uint addMoneyVal;
    //[SerializeField] SpawnAnimMoney spawnAnimMoneyGO;

    public void OnWatchVideoButtonClicked()
    {
        adVideoGO.SetActive(true);
    }

    //public void OnVideoEndAddMoney()
    //{
        
    //    CashScript.Add(addMoneyVal);
    //    spawnAnimMoneyGO.Spawn();
    //}
}
