using UnityEngine;

public class LayoutEmptyShowPlayButton : MonoBehaviour
{
    [SerializeField] GameObject playButtonGO;
    [SerializeField] GameObject levelTextGO;
    void Update()
    {
        if (transform.childCount == 0)
        {
            playButtonGO.SetActive(true);
            levelTextGO.SetActive(true);
        } else
        {
            playButtonGO.SetActive(false);
            levelTextGO.SetActive(false);
        }
    }
}
