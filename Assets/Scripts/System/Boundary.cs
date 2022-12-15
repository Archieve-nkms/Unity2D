using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _affectObjects = new List<GameObject>();

    Vector2 _screenBounds;


    private void Start()
    {
        UpdateBoundary();
    }

    private void Update()
    {
        foreach(GameObject obj in _affectObjects)
        {
            Vector3 pos = obj.transform.position;
            pos.x = Mathf.Clamp(pos.x, _screenBounds.x * -1, _screenBounds.x);
            pos.y = Mathf.Clamp(pos.y, _screenBounds.y * -1, _screenBounds.y);
            obj.transform.position = pos;
        }
    }

    public void UpdateBoundary()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
}