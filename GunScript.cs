using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    GameMaster master;

    // Start is called before the first frame update
    void Start()
    {
        master = Camera.main.GetComponent<GameMaster>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Death")
        {
            //transform.parent.position = Vector3.zero;
            Time.timeScale -= 0.1f;
            master.health--;
            master.audioSource.clip = master.hurt;
            master.UpdateGameMode();

        }

    }
}
