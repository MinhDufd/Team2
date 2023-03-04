using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePos;
    [SerializeField] List<SpawnableObject> spawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePos);

        transform.position = new Vector3(-100, -100, 0);
    }
    public void Spawn()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }
    
}
