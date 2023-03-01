using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamageable
{
    public void TakeDmg(int damage)
    {
        Destroy(gameObject);
    }
}
    