using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _affectObjects = new List<GameObject>();

    Vector3 _bounds;

    private void Start()
    {
        foreach (var enemy in Resources.FindObjectsOfTypeAll<Enemy>())
        {
            AddAffectObject(enemy.gameObject);
        }
        foreach(var projectile in Resources.FindObjectsOfTypeAll<Projectile>())
        {
            AddAffectObject(projectile.gameObject);
        }
        UpdateBoundary();
    }

    private void Update()
    {
        foreach(GameObject obj in _affectObjects)
        {
            if (!CheckObjectIsOutside(obj))
                continue;

            if (obj.GetComponent<Projectile>() != null)
                obj.SetActive(false);
            else
                BlockEscape(obj);
        }
    }

    public void UpdateBoundary()
    {
        _bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void SetBoundary(Vector2 position, Vector3 bounds)
    {
        transform.position = position;
        _bounds = bounds;
    }

    public void AddAffectObject(GameObject obj)
    {
        if (_affectObjects.Contains(obj))
            return;

        _affectObjects.Add(obj);
    }

    bool CheckObjectIsOutside(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        if (Mathf.Abs(pos.x) > _bounds.x || Mathf.Abs(pos.y) > _bounds.y)
            return true;
        else
            return false;
    }

    void BlockEscape(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        pos.x = Mathf.Clamp(pos.x, _bounds.x * -1, _bounds.x);
        pos.y = Mathf.Clamp(pos.y, _bounds.y * -1, _bounds.y);
        obj.transform.position = pos;
    }
}