using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject _weaponSelection;

    private void Start()
    {
        _weaponSelection.SetActive(false);
    }

    public void OpenWeaponSelection()
    {
        _weaponSelection.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextWeapon()
    {
        Managers.Game.SelectedWeaponIndex = (Managers.Game.SelectedWeaponIndex + 1) % Managers.Game.WeaponList.Count;
        FindObjectOfType<TextWeaponSelection>().UpdateText();
    }

    public void PreviousWeapon()
    {
        Managers.Game.SelectedWeaponIndex = Managers.Game.SelectedWeaponIndex - 1;
        if (Managers.Game.SelectedWeaponIndex < 0)
            Managers.Game.SelectedWeaponIndex = Managers.Game.WeaponList.Count - 1;

        FindObjectOfType<TextWeaponSelection>().UpdateText();
    }
}