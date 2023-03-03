using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    Transform targetDesination;
    GameObject targetGameobject;
    Character targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rgbd2d;

    [SerializeField] int HP = 10;
    [SerializeField] int damage=5;

    [SerializeField] int exp_reward = 400;

    private void Awake()
    {
        rgbd2d= GetComponent<Rigidbody2D>();
        
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDesination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDesination.position - transform.position).normalized;
        rgbd2d.velocity= direction * speed; 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject== targetGameobject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null) 
        {
            targetCharacter = targetGameobject.GetComponent<Character>(); 
        }
        targetCharacter.TakeDamage(damage);
    }
    public void TakeDmg(int damage)
    {
        HP -= damage;
        if(HP < 1)
        {
            targetGameobject.GetComponent<Level>().AddExperience(exp_reward);
            Destroy(gameObject);
        }
    }
    
}
