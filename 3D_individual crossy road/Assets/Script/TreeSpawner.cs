using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject TreePrefabs;
    [SerializeField] TerrainBlock terrain;
    [SerializeField] int count = 3;

    private void Start() {
        List<Vector3> emptyPos = new List<Vector3>();

        for (int i = -terrain.Extend; i < terrain.Extend; i++)
        {
            if(transform.position.z == 0 && i == 0)
            {
                continue;
            }
            emptyPos.Add(transform.position + Vector3.right * i);
        }

        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0,emptyPos.Count);
            var spawnPosition = emptyPos[index];

            Instantiate(TreePrefabs, spawnPosition, Quaternion.identity, this.transform);

            emptyPos.RemoveAt(index);
        }

        Instantiate(TreePrefabs, transform.position + Vector3.right * -(terrain.Extend +1), Quaternion.identity, this.transform);
        Instantiate(TreePrefabs, transform.position + Vector3.right * (terrain.Extend +1), Quaternion.identity, this.transform);
    }
}
