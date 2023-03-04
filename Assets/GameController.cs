using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public void Awake()
    {
        instance = this; }
    public Transform playerTransform; 
}
