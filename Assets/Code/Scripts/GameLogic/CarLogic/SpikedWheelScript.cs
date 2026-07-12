using UnityEngine;

public class SpikedWheelScript : GeneralUpgradeScript
{
    [SerializeField] GameObject spikedWheel;
    [SerializeField] GameObject simpleWheel;
    [SerializeField] bool firstSpiked;
    private bool change = false;
    private void Start()
    {
        change = firstSpiked;
        spikedWheel.SetActive(change);
        simpleWheel.SetActive(!change);
    }
    

    protected override void OnClick()
    {
        change = !change;

        spikedWheel.SetActive(change);
        simpleWheel.SetActive(!change);
        WheelJoint2D[] joints = carGO.GetComponents<WheelJoint2D>();

        foreach (WheelJoint2D joint in joints)
        {
            joint.enabled = false;
            joint.enabled = true;
        }
    }
}
