using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    private void Start()
    {
        Managers.Game.StartGame();
    }
}