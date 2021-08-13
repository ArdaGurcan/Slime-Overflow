using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip next;
    public AudioClip hurt;
    public int gamemode = 0;
    int lastGamemode;
    public GameObject pong;
    public GameObject escaper;
    public GameObject shooter3d;
    public GameObject platformer;
    public GameObject breakout;
    public GameObject rhythm;
    public GameObject player;
    float interval = 0;
    float pastTime = 0;
    public int health = 5;
    public int score = 0;
    public GameObject[] hearts;
    public Text scoreText;
    public GameObject gameOver;
    public Text gameOverScore;

    private void Awake()
    {
        gamemode = 1;//Random.Range(0, 6);
        lastGamemode = gamemode;
        gameOver.SetActive(false);
    }

    public void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateGameMode();
        
    }

    void Update()
    {
        
        scoreText.text = score + "";
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i >= health)
            {
                hearts[i].SetActive(false);
            }
        }
        if(health < 0)
        {
            if(Input.anyKeyDown)
            {
                Reload();
            }
            Time.timeScale = 0.01f;
            gameOverScore.text = score + "";
            gameOver.SetActive(true);
        }
        pastTime += Time.deltaTime;
        if(pastTime > interval)
        {
            pastTime = 0;
            audioSource.clip = next;
            UpdateGameMode();
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    UpdateGameMode();
        //}
    }

    public void UpdateGameMode()
    {
        audioSource.Play();
        score += Mathf.RoundToInt(interval * Time.timeScale * Time.timeScale * 7);
        interval = Random.Range(5, 20);
        while (gamemode == lastGamemode)
        {
            gamemode = Random.Range(0, 6);

        }
        lastGamemode = gamemode;
        //UpdateGameMode();
        pong.SetActive(false);
        escaper.SetActive(false);
        shooter3d.SetActive(false);
        platformer.SetActive(false);
        breakout.SetActive(false);
        rhythm.SetActive(false);
        switch (gamemode)
        {
            default:
                break;
            case 0:     // pong
                pong.SetActive(true);
                break;
            case 1:     // escaper
                escaper.SetActive(true);
                break;
            case 2:     // 3d shooter
                shooter3d.SetActive(true); 
                break;
            case 3:     // platformer
                platformer.SetActive(true);
                break;
            case 4:     // breakout
                breakout.SetActive(true);
                break;
            case 5:     // breakout
                rhythm.SetActive(true);
                break;
        }
        if (gamemode == 2)
        {
            player.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(MoveOverSeconds(gameObject, player.transform.position + new Vector3(0, 2.3599999f, -1.99000001f), 1f));
            StartCoroutine(RotateOverSeconds(gameObject, Quaternion.Euler(20.42f, 0, 0), 1f));
            
        }
        else
        {
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(0, 0, -10f), 1f));
            StartCoroutine(RotateOverSeconds(gameObject, Quaternion.Euler(0, 0, 0), 1f));
        }



        //if (gamemode != 1)

        int l = escaper.transform.childCount;
        {
            for (int i = 0; i < l; i++)
            {
                if(i > 3)
                {
                    Destroy(escaper.transform.GetChild(i).gameObject);
                }
            }
        }
        //if (gamemode != 2)
        l = shooter3d.transform.childCount;
        {
            for (int i = 0; i < l; i++)
            {
                if (i > 0)
                {
                    Destroy(shooter3d.transform.GetChild(i).gameObject);
                }
            }
        }
        //if (gamemode != 3)
        l = platformer.transform.childCount;
        {
            for (int i = 0; i < l; i++)
            {
                if (i > 3)
                {
                    Destroy(platformer.transform.GetChild(i).gameObject);
                }
            }
        }
        //if (gamemode != 4)
        l = breakout.transform.childCount;
        {
            for (int i = 0; i < l; i++)
            {
                if (breakout.transform.childCount >= 6)
                {
                    Destroy(breakout.transform.GetChild(5).gameObject);
                }
            }
        }
        l = rhythm.transform.childCount;
        for (int i = 0; i < l; i++)
        {
            if (i >= 1)
            {
                Destroy(rhythm.transform.GetChild(i).gameObject);
            }
        }

        player.GetComponent<Player>().Start();
        if (gamemode == 4)
        {
            breakout.transform.GetChild(0).GetComponent<PaddeScript>().Start();
        }
        if (gamemode == 5)
        {
            rhythm.transform.position = player.transform.position;
        }
        if (gamemode == 3)

        {
            platformer.GetComponent<Platformer>().lastScale = -5;
        }
        Time.timeScale += 0.05f;
        
        
    }

    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
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

    public IEnumerator RotateOverSeconds(GameObject objectToMove, Quaternion end, float seconds)
    {
        float elapsedTime = 0;
        Quaternion startingPos = objectToMove.transform.rotation;
        while (elapsedTime < seconds)
        {
            transform.rotation = Quaternion.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.rotation = end;
    }


}
