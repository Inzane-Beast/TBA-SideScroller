using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrant : MonoBehaviour
{
    public bool PlayerHitHydrant = false;
    private Collider col;
    void Start()
    {
        PlayerHitHydrant = false;
        col = this.gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHitHydrant = true;
            col.enabled = false;
        }
    }
}
