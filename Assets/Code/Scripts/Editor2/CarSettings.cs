using System;
using UnityEngine;

[Serializable]
public struct CarSettings
{
    public CarSettings(int cr = 0, bool r = false, bool sw = false, bool prop = false, bool wing = false) {
        _carModel = cr;
        _rocket = r;
        spikedWheels = sw;
        propeller = prop;
        _wings = wing;
    }

    [SerializeField]
    private int _carModel;

    public int carModel
    {
        get { return _carModel; }
        set
        {
            if (value >= 3)
            {
                _carModel = 3;
            }
            else if (value < 0)
            {
                _carModel = 0;
            }
            else
            {
                _carModel = value;
            }
        }
    }

    public bool spikedWheels;

    [SerializeField]
    private bool _rocket;
    public bool rocket
    {
        get { return _rocket; }
        set
        {
            if (_wings) _wings = false;
            _rocket = value;
        }
    }
    public bool propeller;

    [SerializeField]
    private bool _wings;
    public bool wings
    {
        get { return _wings; }
        set
        {
            if (_rocket) _rocket = false;
            _wings = value;
        }
    }
}
