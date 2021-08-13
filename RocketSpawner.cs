using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocket;
    // Start is called before the first frame update
    public void Start()
    {
        InvokeRepeating("Spawn", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if(gameObject.activeInHierarchy)
        {
            Instantiate(rocket, new Vector3((Random.Range(0, 2) - 0.5f) * 2 * 8.5f, (Random.Range(0, 2) - 0.5f) * 2 * 5.5f), Quaternion.identity, transform);

        }
    }
}
