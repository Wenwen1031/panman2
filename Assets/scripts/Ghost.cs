using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    public float speed;
    public int dec;//0 left 1 right 2 top 3 down
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = new LevelGenerator();
        dec = Random.Range(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        switch (dec)
        {
            case 0:
                {
                    this.transform.GetComponent<Animator>().SetInteger("act", 0);
                    this.transform.Translate(-speed * 0.02f, 0, 0);
                }break;
            case 1:
                {
                    this.transform.GetComponent<Animator>().SetInteger("act", 1);
                    this.transform.Translate(speed * 0.02f, 0, 0);
                }
                break;
            case 2:
                {
                    this.transform.GetComponent<Animator>().SetInteger("act", 2);
                    this.transform.Translate(0, speed * 0.02f, 0);
                }
                break;
            case 3:
                {
                    this.transform.GetComponent<Animator>().SetInteger("act", 3);
                    this.transform.Translate(0, -speed * 0.02f, 0);
                }
                break;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("wall"))
        {
            List<int> vs = levelGenerator.getList(this.transform.position);
            dec = vs[Random.Range(0, vs.Count)];
          
        }
    }
}
