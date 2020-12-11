using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem coinparticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //this.gameObject.SetActive(false);

            destroy();
        }
    }

    private void destroy()
    {
        Instantiate(coinparticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
