using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Static akan membuat variable di shared pada semua Tree
    public static List<Vector3> AllPositions = new List<Vector3>();

    private void OnEnable()
    {
        AllPositions.Add(this.transform.position);
        Debug.Log(AllPositions.Count);
    }

    private void OnDisable()
    {
        AllPositions.Remove(this.transform.position);
    }
}
