using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = transform.position;
        Vector3 pos = Vector3.up * Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        pos = Vector3.ClampMagnitude(pos, 4f);
        Vector3 newPos = transform.position + new Vector3(0, pos.y, 0);
        if(!((newPos.y < -4.001f && pos.y < 0) || (newPos.y > 4.001f && pos.y > 0)))
        {

            transform.position += new Vector3(0, pos.y, 0);
        }
        

    }
}
