using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_BASE_TEXT : MonoBehaviour
{
    [SerializeField] protected TMPro.TextMeshProUGUI _text;

    private void Awake()
    {
        if (_text == null)
            _text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateText();
    }

    public abstract void UpdateText();
}
