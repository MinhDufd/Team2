using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IPickUpObject
{
    [SerializeField] int amount;
    public void OnPickUp(Character character)
    {
        character.level.AddExperience(amount);
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
