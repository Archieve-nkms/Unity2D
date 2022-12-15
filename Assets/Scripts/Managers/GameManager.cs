using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player _player;
    float _startTick;

    public Player Player => _player;
    public float StartTick => _startTick;
    public float ElpasedTick => Time.time - _startTick;
    public int ElapsedSeconds => (int)Mathf.Floor(ElpasedTick);

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public void StartGame()
    {
        _startTick = Time.time;
    }
}