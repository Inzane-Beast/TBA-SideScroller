using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private PlatformManager _platformMnger;

    public void OnEnable()
    {
        _platformMnger = GameObject.FindObjectOfType<PlatformManager>();
    }

  
    private IEnumerator OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            yield return new WaitForSeconds(0f);
            Debug.Log("collided with platform end");
            _platformMnger.RecyclePlatform(this.gameObject);
        }
    }
}
