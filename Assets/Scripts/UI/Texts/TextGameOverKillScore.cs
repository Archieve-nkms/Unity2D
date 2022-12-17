using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGameOverKillScore : UI_BASE_TEXT
{
    private void OnEnable()
    {
        UpdateText();    
    }

    public override void UpdateText()
    {
        _text.text = $"{Managers.Game.KillCount}";
    }
}