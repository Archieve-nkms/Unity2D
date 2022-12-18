using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player _player;
    float _startTick;
    int _killCount = 0;

    public Player Player => _player;
    public float StartTick => _startTick;
    public float ElapasedTick => Time.time - _startTick;
    public int ElapsedSeconds => (int)Mathf.Floor(ElapasedTick);
    public int ElapsedMinutes => (int)Mathf.Floor(ElapsedSeconds / 60);
    public int KillCount { get { return _killCount; } set { _killCount = value; } }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public void StartGame()
    {
        _startTick = Time.time;
        _killCount = 0;
        _player.gameObject.SetActive(true);
        _player.transform.position = new Vector3(0,0);
        Managers.Pool.InactiveAll();
        FindObjectOfType<InGame>().StartEnemySpawner();
        FindObjectOfType<TextRemainingHP>().UpdateText();
    }

    public void EndGame()
    {
        GameObject go = Resources.FindObjectsOfTypeAll<ButtonInGame>()[0].gameObject;
        go.SetActive(true);
        FindObjectOfType<InGame>().StopEnemySpawner();
    }
}