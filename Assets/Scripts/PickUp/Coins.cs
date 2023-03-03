using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAccquired; 
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    public void Add(int count)
    {
        coinAccquired += count;
        coinsCountText.text ="Coins :" +coinAccquired.ToString();
    }
}
