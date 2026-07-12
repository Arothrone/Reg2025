using UnityEngine;

public class Resolution
{
    public static Resolution[] defaultResolutions = {new Resolution(1280, 720),
    new Resolution(1366, 768), 
    new Resolution(1600, 900), 
    new Resolution(1920, 1080)};


    public Resolution(int x, int y)
    {
        width = x;
        height = y;
    }

    

    public void SetCustomResolution(bool fullScreen = true)
    {
        Screen.SetResolution(width, height, fullScreen);
    }

    public string StringConvert()
    {
        return width.ToString()+":"+height.ToString();
    }

    private readonly int width;
    private readonly int height;
}
