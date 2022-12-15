using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    Resolution _resolution = new Resolution(1280,720);

    public Resolution Resolution => _resolution;

    private void Start()
    {
        SetResolution(_resolution, false);
    }

    private void Update()
    {
        if (_resolution.width != Screen.width || _resolution.height != Screen.height)
        {
            _resolution = new Resolution(Screen.width, Screen.height);
            SetResolution(Resolution, Screen.fullScreen);
        }
    }

    public void SetResolution(Resolution resolution, bool isfullScreen)
    {
        int widthRatio = resolution.width / Screen.width;
        int heightRatio = resolution.height / Screen.height; 

        Screen.SetResolution(resolution.width, resolution.height, isfullScreen);

        List<SpriteRenderer> spriteRenderers = Resources.FindObjectsOfTypeAll<SpriteRenderer>().ToList();
        foreach(var sprite in spriteRenderers)
        {
            sprite.size.Scale(new Vector2(widthRatio, heightRatio));
        }
    }
}

[System.Serializable]
public class Resolution
{
    public int width;
    public int height;

    public Resolution(int width, int height) 
    { 
        this.width = width; 
        this.height = height; 
    }
}