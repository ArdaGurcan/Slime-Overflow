using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    GameObject player;
    public GameObject obstacle;
    public int lastScale = -5;
    // Start is called before the first frame update

    public void Start()
    {
        lastScale = 3;
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Spawn", 0, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 20f);
    }

    void Spawn()
    {
        GameObject newObstacle = Instantiate(obstacle, new Vector3(12, -5), Quaternion.identity, transform);
        int scale = lastScale;
        while(scale == lastScale)
        {
            scale = Mathf.Clamp(Random.Range(-4, 5) + lastScale, 4, 12);

        }
        newObstacle.GetComponent<SpriteRenderer>().size = new Vector2(1.75f, Mathf.Clamp(lastScale, 4, 12)/1);
        newObstacle.GetComponent<BoxCollider2D>().size = new Vector2(1.75f, Mathf.Clamp(lastScale, 4, 12)/1);
        //newObstacle.transform.localScale = new Vector3(2, Mathf.Clamp(lastScale, 4, 12));
        lastScale = scale;
    }
}
