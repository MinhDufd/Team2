using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    Vector3 moveVector;
    [SerializeField] float speed = 5f;

    Animate animate;
    private void Awake()
    {
       rgbd2d= GetComponent<Rigidbody2D>();
        moveVector = new Vector3();
        animate = GetComponent<Animate>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        animate.horizontal = moveVector.x;
        moveVector*= speed;
         rgbd2d.velocity= moveVector;
    }
}
