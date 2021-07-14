using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TurretBlueprint
{
    [Header("Base")]
    public GameObject prefab; // Префаб сооружения
    public int cost; // Стоимость оборудования
    [Header("Upgrade")]
    public GameObject upgradePrefab;
    public int upgradeCost;
    
    public int GetSellCost()
    {
        return cost / 2;
    }
}
