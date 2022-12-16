using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static GameManager _game;
    static ScreenManager _screen;
    static PoolManager _pool;

    public static GameManager Game => _game;
    public static ScreenManager Screen => _screen;
    public static PoolManager Pool => _pool;

    void Awake()
    {
        if(FindObjectOfType<Managers>() != null)
            Destroy(this.gameObject);

        this.transform.name = $"@Managers";

        _screen = CreateManager<ScreenManager>();
        _game = CreateManager<GameManager>();
        _pool = CreateManager<PoolManager>();

        DontDestroyOnLoad(this);
    }

    T CreateManager<T>() where T : MonoBehaviour
    {
        T manager = new GameObject($"{typeof(T)}").AddComponent<T>();
        manager.transform.SetParent(this.transform);

        return manager;
    }
}