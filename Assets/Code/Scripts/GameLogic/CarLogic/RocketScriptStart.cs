using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketScriptStart : GeneralUpgradeScript
{
    public static bool isGameStarted = false;
    [SerializeField] RocketScript rocketScript;
    protected override void OnClick()
    {
        if (isGameStarted) StartCoroutine(RunLater());
    }

    IEnumerator RunLater()
    {
        yield return new WaitForSeconds(0.2f);
        rocketScript.Prep();
        GetComponent<RocketScriptStart>().enabled = false;
    }
}
