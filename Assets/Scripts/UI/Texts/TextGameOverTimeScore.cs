using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGameOverTimeScore : UI_BASE_TEXT
{
    private void OnEnable()
    {
        UpdateText();
    }

    public override void UpdateText()
    {
        int minutes = Managers.Game.ElapsedSeconds / 60;
        int seconds = Managers.Game.ElapsedSeconds % 60;
        _text.text = $"{string.Format("{0:00}", minutes)}:{string.Format("{0:00}", seconds)}";
    }
}
