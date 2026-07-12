using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelValue : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<TMP_Text>().text = (SceneManager.GetActiveScene().buildIndex - 2).ToString();
    }
}
