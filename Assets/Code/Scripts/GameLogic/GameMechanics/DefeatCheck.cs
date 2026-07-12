using UnityEngine;

public class DefeatCheck : MonoBehaviour
{
    [SerializeField] WinDefeatGOScriptableObject panelsSO;



    void Update()
    {
        if (panelsSO.defeatPanelGO != null && !panelsSO.winPanelGO.activeSelf)
        {
            if (transform.position.y <= 3 && !panelsSO.defeatPanelGO.activeSelf)
            {
                panelsSO.defeatPanelGO.SetActive(true);
            }
        }
    }
}
