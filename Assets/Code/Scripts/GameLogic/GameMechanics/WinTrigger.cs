using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] WinDefeatGOScriptableObject panelsSO;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (panelsSO.winPanelGO != null && !panelsSO.defeatPanelGO.activeSelf)
        {
            if (collision.gameObject.CompareTag("car"))
            {
                panelsSO.winPanelGO.SetActive(true);
                
            }
        }
    }
}
