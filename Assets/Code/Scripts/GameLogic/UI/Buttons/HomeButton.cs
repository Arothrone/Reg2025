using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
