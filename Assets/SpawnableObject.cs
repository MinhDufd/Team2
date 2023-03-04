using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField] [Range(0,1)] float probablility;

    public void Spawn()
    {
        if (Random.value < probablility)
        {
            GameObject go = Instantiate(toSpawn,transform.position, Quaternion.identity); ;
        }
    }    
}
