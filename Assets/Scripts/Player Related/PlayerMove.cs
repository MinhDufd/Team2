using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 moveVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;


    [SerializeField] float speed = 5f;

    
    private void Awake()
    {
       rgbd2d= GetComponent<Rigidbody2D>();
        moveVector = new Vector3();
        
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

        if (moveVector.x != 0)
        {
            lastHorizontalVector= moveVector.x;
        }if (moveVector.y != 0)
        {
            lastVerticalVector= moveVector.y;
        }
        
        moveVector*= speed;
         rgbd2d.velocity= moveVector;
    }
}
