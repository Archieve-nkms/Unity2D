using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static GameManager _game;
    static ScreenManager _screen;
    static PoolManager _pool;
    static UnitManager _unit;

    public static GameManager Game => _game;
    public static ScreenManager Screen => _screen;
    public static PoolManager Pool => _pool;
    public static UnitManager Unit => _unit;


    void Awake()
    {
        if(FindObjectsOfType<Managers>().Length > 1)
            Destroy(this.gameObject);

        transform.name = $"@Managers";

        _screen = CreateManager<ScreenManager>();
        _game = CreateManager<GameManager>();
        _pool = CreateManager<PoolManager>();
        _unit = CreateManager<UnitManager>();

        DontDestroyOnLoad(this);
    }

    T CreateManager<T>() where T : MonoBehaviour
    {
        T manager = new GameObject($"{typeof(T)}").AddComponent<T>();
        manager.transform.SetParent(this.transform);

        return manager;
    }
}