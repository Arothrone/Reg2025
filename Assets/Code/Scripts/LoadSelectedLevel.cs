using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSelectedLevel : MonoBehaviour
{
    [SerializeField] int levelToLoad;
    public void Load()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
