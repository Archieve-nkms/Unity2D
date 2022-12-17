using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    Object _enemy;
    Object _bullet;

    Coroutine _enemySpawner;

    private void Awake()
    {
        _enemy = Resources.Load("Prefabs/Units/Enemies/Enemy");
        _bullet = Resources.Load("Prefabs/Projectiles/Small Bullet");
    }

    private void Start()
    {
        Managers.Pool.CreatePool(_enemy, 150);
        Managers.Pool.CreatePool(_bullet, 1000);
        Managers.Game.StartGame();
    }

    public void StopEnemySpawner()
    {
        StopCoroutine(_enemySpawner);
    }

    public void StartEnemySpawner()
    {
        _enemySpawner = StartCoroutine(EnemySpawner(3, 6));
    }

    IEnumerator EnemySpawner(int count, int seconds)
    {
        float width = Managers.Screen.worldScreenPos.x;
        float height = Managers.Screen.worldScreenPos.y;

        float xPos;
        float yPos;

        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                xPos = Random.Range(-width, width);
                yPos = Random.Range(-height, height);
                Managers.Unit.SpawnEnemy(_enemy, xPos, yPos);
            }

            yield return new WaitForSeconds(seconds);
        }
    }
}