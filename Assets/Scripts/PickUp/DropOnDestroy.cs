using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject dropItemPrefabs;
    [SerializeField] [Range(0f,1f)] float chance = 0f;

    private void OnDestroy()
    {
        if (Random.value < chance)
        {
            Transform t = Instantiate(dropItemPrefabs).transform;
            t.position = transform.position;
        }
    }
  
}
