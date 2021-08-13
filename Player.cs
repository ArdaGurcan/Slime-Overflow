using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;
    GameMaster master;
    Rigidbody2D rb;
    bool grounded;
    public LayerMask ground;
    public PhysicsMaterial2D bouncy;
    SpriteRenderer sp;

    // Start is called before the first frame update
    public void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        master = Camera.main.GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
        if (master.gamemode == 0) // pong
        {
            rb.velocity = new Vector2(4, (Random.Range(1f, 3f)-0.5f) * 2 * 1.5f);
        }
        else if(master.gamemode == 4)
        {
            rb.velocity = new Vector2((Random.Range(1f, 3f) - 0.5f) * 2 * 1.5f, 2);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(master.gamemode != 2)
        {
            if (Mathf.Abs(transform.position.x) < 2.57 && Mathf.Abs(transform.position.y) < 2)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        if(master.gamemode == 1) // escape
        {
            
            rb.sharedMaterial = null;
            rb.MovePosition(transform.position + Vector3.Normalize(Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")) * 10 * Time.deltaTime);
        }
        else if(master.gamemode == 0)
        {
            rb.sharedMaterial = bouncy;
        }
        else if(master.gamemode == 3)
        {
            rb.sharedMaterial = null;
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 6, rb.velocity.y);
            grounded = Physics2D.OverlapCircle(transform.position - Vector3.down * 0.05f, 1f, ground);
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                //rb.velocity = Vector3.zero;
                
                rb.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
            }
            if(grounded)
            {
                rb.velocity += new Vector2(-2, 0);
                

            }
        }
        else if (master.gamemode == 4)
        {
            rb.sharedMaterial = bouncy;
        }
        if(rb.velocity.x > 0.1f)
        {
            sp.flipX = false;
        }
        else if(rb.velocity.x < -0.1f)
        {
            sp.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Death" || collision.tag == "Rocket")
        {
            transform.position = Vector3.zero;
            Time.timeScale -= 0.1f;
            master.health--;
            master.audioSource.clip = master.hurt;
            master.UpdateGameMode();
            //transform.position = Vector3.zero;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(4, (Random.Range(1f, 3f) - 0.5f) * 2 * 1.5f);
            //if(transform.position.x < 0)
            //{
            //    health--;
            //}
        }
    }
    
}
