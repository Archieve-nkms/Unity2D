using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static GameManager _game;
    static ScreenManager _screen;

    public static GameManager Game => _game;
    public static ScreenManager Screen => _screen;


    void Awake()
    {
        this.transform.name = $"@Managers";

        _screen = CreateManager<ScreenManager>();
        _game = CreateManager<GameManager>();

        DontDestroyOnLoad(this);
    }

    T CreateManager<T>() where T : MonoBehaviour
    {
        T manager = new GameObject($"{typeof(T)}").AddComponent<T>();
        manager.transform.SetParent(this.transform);

        return manager;
    }
}