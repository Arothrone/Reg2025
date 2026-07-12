using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelValueEditor : MonoBehaviour
{
    public static int currentLevelValue = -1;
    [SerializeField] TMP_Text levelValueTextToChange;
    
    private void Update()
    {
        if (currentLevelValue > -1 && GameEditorMainLogic.gameStarter != null)
        {
            levelValueTextToChange.text = (currentLevelValue + 1).ToString();
        }
    }
}
