using TMPro;
using UnityEngine;

public class TextLanguageSetScript : MonoBehaviour
{
    [SerializeField] string langTag;
    void Start()
    {
        UpdateLan();
    }

    void UpdateLan()
    {
        LangInfo langData = CurrentLanguage.langs[Settings.currentSettings.languageIndex];
        transform.GetComponent<TMP_Text>().text = langData.lang[langTag];
    }

    public static void RestartLanguage()
    {
        TextLanguageSetScript[] myScripts = FindObjectsByType<TextLanguageSetScript>(FindObjectsSortMode.None);

        foreach (TextLanguageSetScript script in myScripts)
        {
            script.UpdateLan();
        }
    }
}
