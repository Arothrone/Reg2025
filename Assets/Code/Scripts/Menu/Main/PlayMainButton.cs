using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMainButton : MonoBehaviour
{
    public void OnMainButtonPressed()
    {
        SceneManager.LoadScene(2);
    }
}
