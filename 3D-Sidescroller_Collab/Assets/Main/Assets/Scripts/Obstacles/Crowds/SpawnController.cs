using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{   
    public GameObject ped_prefab;
    public InteractionWithPedestrian int_ped;
    // Start is called before the first frame update
    void Start()
    {
        ped_prefab = GetComponent<GameObject>();
        int_ped = FindObjectOfType<InteractionWithPedestrian>();
        ped_prefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (int_ped.playerhitspawn)
        {
            ped_prefab.SetActive(true);
        }
        else
        {
            ped_prefab.SetActive(false);
        }
        if (int_ped.playerhitdestroy)
        {
            ped_prefab.SetActive(false);
        }
        else
        {
            ped_prefab.SetActive(true);
        }
    }

}
