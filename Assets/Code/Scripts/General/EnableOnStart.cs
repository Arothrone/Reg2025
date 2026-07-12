using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    [SerializeField] GameObject toEnable;
    private void Start()
    {
        if (toEnable == null)
        {
            return;
        }
        toEnable.SetActive(true);
    }
}
