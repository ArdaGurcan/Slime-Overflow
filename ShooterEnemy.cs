using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < transform.parent.position.y)
        {
            transform.position += transform.up * Time.deltaTime * 5;
        }
        Quaternion rot = transform.rotation;

        
        transform.LookAt(player.GetChild(0));
        //transform.rotation = Quaternion.Euler(rot.eulerAngles.x, transform.rotation.y, rot.eulerAngles.z);
        //transform.rotation = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, Quaternion.LookRotation(player.position-transform.position, player.up).eulerAngles.z);
        transform.position += transform.forward * Time.deltaTime * 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }
}
