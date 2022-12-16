using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    Object _enemy;
    Object _bullet;

    private void Awake()
    {
        _enemy = Resources.Load("Prefabs/Units/Enemy");
        _bullet = Resources.Load("Prefabs/Projectiles/Small Bullet");
    }

    private void Start()
    {
        Managers.Game.StartGame();
        Managers.Pool.CreatePool(_enemy, 150);
        Managers.Pool.CreatePool(_bullet, 800);
    }
}