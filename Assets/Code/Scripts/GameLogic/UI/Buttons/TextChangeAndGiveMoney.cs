using TMPro;
using UnityEngine;

public class TextChangeAndGiveMoney : GetMoney
{
    [SerializeField] TMP_Text multiplierText;
    [SerializeField] uint multiuplierValue;
    [SerializeField] TMP_Text amountOfMoneyText;
    [SerializeField] GameObject multiplyButtonGO;
    [SerializeField] GameObject noThanksTextGO;
    [SerializeField] GameObject nextLevelTextGO;

    private void Start()
    {
        amountOfMoneyText.text = "+" + addMoneyVal.ToString();
        multiplierText.text = "X" + multiuplierValue.ToString();

        AddMoney();
    }

    public void GetMoneyAfterAd()
    {
        if (noThanksTextGO != null && nextLevelTextGO != null) {
            noThanksTextGO.SetActive(false);
            nextLevelTextGO.SetActive(true);
        }
        multiplyButtonGO.SetActive(false);

        addMoneyVal *= multiuplierValue;

        amountOfMoneyText.text = "+" + addMoneyVal.ToString();

        addMoneyVal = addMoneyVal - (addMoneyVal / multiuplierValue);

        AddMoney();
    }

}
