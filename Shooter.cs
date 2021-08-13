using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;
    public GameObject enemy;
    float cooldown = 0.7f;
    float timeSinceLastShot = 0;
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Spawn", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.UpArrow) && timeSinceLastShot >= cooldown)
        {
            GameObject launched = Instantiate(bullet, player.transform.position + Vector3.forward * 1, Quaternion.Euler(90,0,0), transform);
            timeSinceLastShot = 0;

            //launched.GetComponent<Rigidbody>().velocity = launched.transform.up * 5;
        }
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * Time.deltaTime * -30, 0);
    }

    void Spawn()
    {
        if(gameObject.activeInHierarchy)
        {

        Instantiate(enemy, player.transform.position  + transform.right * Random.Range(-10f,10f) + Vector3.up * (-1.2f) + transform.forward * Random.Range(10,20), Quaternion.Euler(0, 0, 0), transform);
        }

    }
}
