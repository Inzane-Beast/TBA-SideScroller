using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int m_coins;
    
    void Start()
    {
        m_coins = 0;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            m_coins = m_coins + 1;
            FindObjectOfType<AudioManager>().Play("C1");
            
        }
    }
}
