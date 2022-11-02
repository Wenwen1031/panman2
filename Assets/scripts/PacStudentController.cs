using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float speed;


    public GameObject score;
    public GameObject gametime;
    public GameObject[] liver;
    private int livercount = 3;
    private float scorecount = 0f;

    float timegame = 0;

    public GameObject backs;
    public GameObject back_text;


    public AudioClip[] audioClips;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("onTime", 1f, 0.1f);
        InvokeRepeating("addcube", 3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, speed * 0.02f, 0);
            this.transform.GetComponent<Animator>().SetInteger("act",1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed * 0.02f, 0);
            this.transform.GetComponent<Animator>().SetInteger("act",4);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed * 0.02f, 0, 0);
            this.transform.GetComponent<Animator>().SetInteger("act",2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * 0.02f, 0, 0);
            this.transform.GetComponent<Animator>().SetInteger("act", 3);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("ennmy"))
        {
            livercount--;
            if (livercount <= 0)
            {
                //unwin
                backs.SetActive(true);
                back_text.transform.GetComponent<TextMeshProUGUI>().text = "Unwin";
                PlayerPrefs.SetString("score", score.transform.GetComponent<TextMeshProUGUI>().text);
                PlayerPrefs.SetString("gametime", gametime.transform.GetComponent<TextMeshProUGUI>().text);
            }
            //liver[livercount].SetActive(false);
            Destroy(liver[livercount]);
            //liver.transform.GetComponent<TextMeshProUGUI>().text = "liver:" + livercount;
            this.transform.GetComponent<Animator>().SetInteger("act", 6);
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
        }else if (collision.collider.tag.Equals("food1"))
        {
            Destroy(collision.collider.gameObject);
            scorecount += 10;
            score.transform.GetComponent<TextMeshProUGUI>().text = "score:" + scorecount;
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
        }else if (collision.collider.tag.Equals("wall"))
        {
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("food2"))
        {
            Destroy(collision.gameObject);
            scorecount += 1;
            GameObject.Find("Mc").transform.GetComponent<LevelGenerator>().listgamecount--;
            if (GameObject.Find("Mc").transform.GetComponent<LevelGenerator>().listgamecount <= 0)
            {
                //win
                backs.SetActive(true);
                back_text.transform.GetComponent<TextMeshProUGUI>().text = "Win";
                PlayerPrefs.SetString("score", score.transform.GetComponent<TextMeshProUGUI>().text);
                PlayerPrefs.SetString("gametime", gametime.transform.GetComponent<TextMeshProUGUI>().text);
            }
            score.transform.GetComponent<TextMeshProUGUI>().text = "score:" + scorecount;
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
        }
        else if (collision.tag.Equals("food1"))
        {
            Destroy(collision.gameObject);
            //scorecount += 10;
            //score.transform.GetComponent<TextMeshProUGUI>().text = "score:" + scorecount;
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
        }
        else if (collision.tag.Equals("food3"))
        {
            Destroy(collision.gameObject);
            scorecount += 10;
            score.transform.GetComponent<TextMeshProUGUI>().text = "score:" + scorecount;
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
        }
        //else if (collision.tag.Equals("ennmy"))
        //{
        //    livercount--;
        //    if (livercount <= 0)
        //    {
        //        //unwin
        //    }
        //    liver.transform.GetComponent<TextMeshProUGUI>().text = "liver:" + livercount;
        //}
    }

    public void onTime()
    {
        timegame += 0.1f * 60;

        gametime.transform.GetComponent<TextMeshProUGUI>().text = "Gametime:" + (int)(timegame / 3600 % 3600) + ":" + (int)(timegame / 60 % 60) + ":" + (int)(timegame % 60);
    }

    public void addcube()
    {
        int r = Random.Range(0, GameObject.Find("Mc").transform.GetComponent<LevelGenerator>().listgame.Count);
        GameObject game = Instantiate<GameObject>(GameObject.Find("Mc").transform.GetComponent<LevelGenerator>().gameObjects[5]);
        game.transform.position = GameObject.Find("Mc").transform.GetComponent<LevelGenerator>().listgame[r];
        //game.transform.parent = GameObject.Find("Mc").transform;
    }
}
