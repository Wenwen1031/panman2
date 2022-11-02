using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addcube", 3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addcube()
    {
        int r = Random.Range(0, GameObject.Find("Mc").transform.GetComponent<LevelGenerator>().listgame.Count);
        GameObject game = Instantiate<GameObject>(GameObject.Find("Mc").transform.GetComponent<LevelGenerator>().gameObjects[7]);
        game.transform.position = GameObject.Find("Mc").transform.GetComponent<LevelGenerator>().listgame[r];
        //game.transform.parent = GameObject.Find("Mc").transform;
    }
}
