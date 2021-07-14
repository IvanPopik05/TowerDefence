using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;
    private void Awake() {
        points = new Transform[transform.childCount]; //childCount - это число дочерних элементов, родитель не включён в подсчёт
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); // GetChild - это число дочерних элементов по индексу
        }
    }
}
