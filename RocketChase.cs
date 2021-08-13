using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketChase : MonoBehaviour
{
    Transform player;
    GameObject[] rockets;
    Rigidbody2D rb;
    GameMaster master;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        rb = GetComponent<Rigidbody2D>();
        master = Camera.main.GetComponent<GameMaster>();
    }

    void Update()
    {
        rockets = GameObject.FindGameObjectsWithTag("Rocket");
        Vector3 diff = player.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        
        
        rb.velocity = (transform.right * 3f * diff.magnitude * diff.magnitude);

        for (int i = 0; i < rockets.Length; i++)
        {
            Vector3 direction = (transform.position - rockets[i].transform.position).normalized;
            rb.velocity += (Vector2)(2f * direction / (1 + (transform.position.y - rockets[i].transform.position.y) * (transform.position.y - rockets[i].transform.position.y) + (transform.position.x - rockets[i].transform.position.x) * (transform.position.x - rockets[i].transform.position.x)));

        }
        if(master.gamemode != 1)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
    }
}
