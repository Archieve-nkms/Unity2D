using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _affectObjects = new List<GameObject>();

    Vector3 _bounds;


    private void Start()
    {
        UpdateBoundary();
    }

    private void Update()
    {
        foreach(GameObject obj in _affectObjects)
        {
            Vector3 pos = obj.transform.position;
            pos.x = Mathf.Clamp(pos.x, _bounds.x * -1, _bounds.x);
            pos.y = Mathf.Clamp(pos.y, _bounds.y * -1, _bounds.y);
            obj.transform.position = pos;
        }
    }

    public void UpdateBoundary()
    {
        _bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void SetBoundary(Vector3 bounds)
    {
        _bounds = bounds;
    }
}