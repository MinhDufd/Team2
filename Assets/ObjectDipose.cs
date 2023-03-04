using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDipose : MonoBehaviour
{
    Transform playerTransform;
    float maxDistance =10f;

    private void Start()
    {
        playerTransform = GameController.instance.transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > maxDistance )
        {
            Destroy(gameObject);
        }
    }
}
