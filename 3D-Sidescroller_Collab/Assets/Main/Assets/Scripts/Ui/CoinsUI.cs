using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public CollectCoins clltcins;
    void Start()
    {
        clltcins = FindObjectOfType<CollectCoins>();
    }

    
    void Update()
    {
        coins.text = "$" + clltcins.m_coins.ToString();
    }
}
