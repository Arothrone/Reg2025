using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveWindowScript : MonoBehaviour
{
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject settingWindow;
    [SerializeField] GameObject saveWindow;

    void OnEnable()
    {
        StartCoroutine("Timer10");
    }

    public void YesPressed()
    {
        StopCoroutine("Timer10");
        Settings.CurrentSettingsUpdateAndUpply();
        SetAllUnactive();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NoPressed()
    {
        StopCoroutine("Timer10");
        Settings.RestorePreviousSettings();
        Settings.CurrentSettingsUpdateAndUpply();
        SetAllUnactive();
    }

    IEnumerator Timer10()
    {
        for (int i = 10; i >= 0; i--)
        {
            timerText.GetComponent<TMP_Text>().text = i.ToString();
            yield return new WaitForSeconds(1.0f);
        }
        
        SetAllUnactive();
    }

    public void OnBackgroundPressed()
    {
        NoPressed();
    }

    private void SetAllUnactive()
    {
        saveWindow.SetActive(false);
        settingWindow.SetActive(false);
    }
}
