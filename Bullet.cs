using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.SqrMagnitude(transform.position) > 10000)
        {
            Destroy(gameObject);
        }
        transform.position += transform.up * Time.deltaTime * 10;
    }
}
