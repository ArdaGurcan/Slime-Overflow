using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(MoveOverSpeed(transform.gameObject, new Vector3(transform.position.x, player.transform.position.y, transform.position.z), 5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.x > 0 && player.transform.position.x > 0)
        {
            Vector3 newPos = Vector3.MoveTowards(gameObject.transform.position, new Vector3(transform.position.x, player.transform.position.y, transform.position.z), 6f * Time.deltaTime);
            if(Mathf.Abs(newPos.y) < 4)
            {
                transform.position = newPos;
            }
        }
    }
    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        while (objectToMove.transform.position != end)
        {   
            yield return new WaitForEndOfFrame();
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
