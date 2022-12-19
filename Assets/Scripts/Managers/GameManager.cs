using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player _player;
    float _startTick = 0f;
    int _killCount = 0;
    bool _isGamePaused = false;
    List<BaseWeapon> _weaponList = new List<BaseWeapon>();
    public int _selectedWeaponIndex = 0;

    public Player Player => _player;
    public float StartTick => _startTick;
    public float ElapasedTick => Time.time - _startTick;
    public int ElapsedSeconds => (int)Mathf.Floor(ElapasedTick);
    public int ElapsedMinutes => (int)Mathf.Floor(ElapsedSeconds / 60);
    public int KillCount { get { return _killCount; } set { _killCount = value; } }
    public bool IsGamePaused => _isGamePaused;
    public IReadOnlyList<BaseWeapon> WeaponList => _weaponList;
    public int SelectedWeaponIndex { get { return _selectedWeaponIndex; } set { _selectedWeaponIndex = value; } }
    public BaseWeapon SelectedWeapon => _weaponList[_selectedWeaponIndex];

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        foreach (BaseWeapon weapon in Resources.LoadAll<BaseWeapon>("Database/Weapons/Player"))
        {
            _weaponList.Add(weapon);
        }
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
        ProceedGame();
    }

    public void EndGame()
    {
        GameObject go = Resources.FindObjectsOfTypeAll<ButtonInGame>()[0].gameObject;
        go.SetActive(true);
        FindObjectOfType<InGame>().StopEnemySpawner();
        PauseGame();
    }

    public void PauseGame()
    {
        _isGamePaused = true;
        Time.timeScale = 0;
    }

    public void ProceedGame()
    {
        _isGamePaused = false;
        Time.timeScale = 1;
    }
}