using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public void SpawnEnemy(Object enemyPrefab, float xPos, float yPos)
    {
        GameObject go = Managers.Pool.GetInstance(enemyPrefab) as GameObject;

        go.transform.position = new Vector3(xPos, yPos, 0);
        go.SetActive(true);
    }
}