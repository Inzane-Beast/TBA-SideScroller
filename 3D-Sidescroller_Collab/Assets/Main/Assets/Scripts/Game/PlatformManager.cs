using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platformPrefabs;
    [SerializeField]
    public int _zedoffset;


    void Start()
    {
        for (int i = 0; i < _platformPrefabs.Length; i++)
        {
            Instantiate(_platformPrefabs[i], new Vector3(0, 0, i * 5), Quaternion.Euler(0, 0, 0));
            _zedoffset += 5; 
        }
    }

    public void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, _zedoffset);
        _zedoffset += 5;
    }

}