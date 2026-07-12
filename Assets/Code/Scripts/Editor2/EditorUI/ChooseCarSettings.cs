using UnityEngine;

public class ChooseCarSettings : MonoBehaviour
{
    [SerializeField] HideAllShowOne CarChecks;

    [SerializeField] GameObject spikedCheck;
    [SerializeField] GameObject rocketCheck;
    [SerializeField] GameObject propellerCheck;
    [SerializeField] GameObject wingsCheck;

    private void OnEnable()
    {
        
        UpdateVals();
    }

    private void UpdateVals()
    {
        CarChecks.SelectByIndex(HandleEditorLogic.current.info.carSettings.carModel);

        spikedCheck.SetActive(HandleEditorLogic.current.info.carSettings.spikedWheels);
        rocketCheck.SetActive(HandleEditorLogic.current.info.carSettings.rocket);
        propellerCheck.SetActive(HandleEditorLogic.current.info.carSettings.propeller);
        wingsCheck.SetActive(HandleEditorLogic.current.info.carSettings.wings);
    }

    public void OnCarButtonClick(int value)
    {
        HandleEditorLogic.current.info.carSettings.carModel = value;
        UpdateVals();
    }

    public void SelectSpiked()
    {

        HandleEditorLogic.current.info.carSettings.spikedWheels = !HandleEditorLogic.current.info.carSettings.spikedWheels;
        UpdateVals();
    }

    public void SelectRocket()
    {
        HandleEditorLogic.current.info.carSettings.rocket = !HandleEditorLogic.current.info.carSettings.rocket;
        UpdateVals();
    }

    public void SelectPropeller()
    {
        HandleEditorLogic.current.info.carSettings.propeller = !HandleEditorLogic.current.info.carSettings.propeller;
        UpdateVals();
    }

    public void SelectWings()
    {
        HandleEditorLogic.current.info.carSettings.wings = !HandleEditorLogic.current.info.carSettings.wings;
        UpdateVals();
    }
}
