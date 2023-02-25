using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDesination;
    GameObject targetGameobject;
    [SerializeField] float speed;

    Rigidbody2D rgbd2d;

    private void Awake()
    {
        rgbd2d= GetComponent<Rigidbody2D>();
        targetGameobject = targetDesination.gameObject;
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
        Debug.Log("I'm dying, help!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}