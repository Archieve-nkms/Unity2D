using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWeaponSelection : UI_BASE_TEXT
{
    public override void UpdateText()
    {
        _text.text = Managers.Game.SelectedWeapon.DisplayName;
    }
}