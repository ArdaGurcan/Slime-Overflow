using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddeScript : MonoBehaviour
{
    public GameObject blocks;
    // Start is called before the first frame update
    public void Start()
    {
        Instantiate(blocks, transform.parent);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5;
        pos = Vector3.ClampMagnitude(pos + Vector3.down * 5, 10f) - Vector3.down * 5;
        Vector3 newPos = transform.position + new Vector3(pos.x, 0, 0);
        if (!((newPos.x < -7.001f && pos.x < 0) || (newPos.x > 7.001f && pos.x > 0)))
        {

            transform.position += new Vector3(pos.x, 0, 0);
        }
    }
}
