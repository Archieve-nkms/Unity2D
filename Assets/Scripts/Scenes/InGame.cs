using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InGame : MonoBehaviour
{
    List<Object> _enemies = new List<Object>();
    List<Object> _projectiles;

    Coroutine _enemySpawner;

    private void Awake()
    {
        _enemies = Resources.LoadAll("Prefabs/Units/Enemies").ToList();
        _projectiles = Resources.LoadAll("Prefabs/Projectiles").ToList();
        
    }

    private void Start()
    {
        foreach(Object enemy in _enemies)
        {
            Managers.Pool.CreatePool(enemy, 50);
        }
        foreach (Object projectiles in _projectiles)
        {
            Managers.Pool.CreatePool(projectiles, 500);
        }
        Managers.Game.StartGame();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Managers.Game.IsGamePaused)
                Managers.Game.PauseGame();
            else
                Managers.Game.ProceedGame();
        }
    }

    public void StopEnemySpawner()
    {
        StopCoroutine(_enemySpawner);
    }

    public void StartEnemySpawner()
    {
        _enemySpawner = StartCoroutine(EnemySpawner(5));
    }

    IEnumerator EnemySpawner(int seconds)
    {
        float width = Managers.Screen.worldScreenPos.x;
        float height = Managers.Screen.worldScreenPos.y;

        float xPos;
        float yPos;

        while (true)
        {
            for (int i = 0; i < Managers.Game.ElapsedMinutes + 3; i++)
            {
                xPos = Random.Range(-width, width);
                yPos = Random.Range(-height, height);
                Object enemy = _enemies[Random.Range(0, _enemies.Count)];
                Managers.Unit.SpawnEnemy(enemy, xPos, yPos);
            }

            yield return new WaitForSeconds(seconds);
        }
    }
}