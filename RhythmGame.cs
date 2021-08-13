using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGame : MonoBehaviour
{
    public GameObject shield;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            shield.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            shield.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            shield.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            shield.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }

    void Spawn()
    {
        if(gameObject.activeInHierarchy)
        {
            if(Random.Range(0f,1f) > 0.5f)
            {
                Instantiate(enemy, transform.position + new Vector3((Random.Range(0, 2) - 0.5f) * 2 * 12, 0), Quaternion.identity, transform);
            }
            else
            {
                Instantiate(enemy, transform.position + new Vector3(0, (Random.Range(0, 2) - 0.5f) * 2 * 12), Quaternion.identity, transform);

            }

        }
        //(Random.Range(0,2) -0.5f) * 2
    }
}
