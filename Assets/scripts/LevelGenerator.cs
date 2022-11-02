using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<Vector3> listgame;
    public GameObject[] gameObjects;
    public GameObject[] back;
    public int listgamecount = 0;
    int[,] levelMap =
                     {
                     {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
                     {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
                     {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
                     {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
                     {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
                     {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
                     {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
                     {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
                     {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
                     {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
                     {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
                     {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,3,0,0,0,0,0},
                     {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,3,0,0,0,0,0},
                     {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
                     {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
                     {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
                     {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
                     {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,3,0,0,0,0,0},
                     {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,3,0,0,0,0,0},
                     {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
                     {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
                     {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
                     {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
                     {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
                     {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
                     {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
                     {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
                     {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
                     {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
                     {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
                     };
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 30; ++i)
        {
            for(int j = 0; j < 28; ++j)
            {
                if (levelMap[i, j] == 0)
                {

                }else if (levelMap[i, j] == 1)
                {
                    //GameObject game = Instantiate<GameObject>(gameObjects[0]);
                    //game.transform.parent = back[0].transform;
                    //game.transform.position = new Vector3(-4f+j*0.5f,4f-i*0.5f,0);

                }
                else if (levelMap[i, j] == 2)
                {
                    //GameObject game = Instantiate<GameObject>(gameObjects[1]);
                    //game.transform.parent = back[1].transform;
                    //game.transform.position = new Vector3(-4f + j * 0.5f, 4f-i * 0.5f, 0);


                }
                else if (levelMap[i, j] == 3)
                {
                    //GameObject game = Instantiate<GameObject>(gameObjects[2]);
                    //game.transform.parent = back[2].transform;
                    //game.transform.position = new Vector3(-4f + j * 0.5f, 4f-i * 0.5f, 0);


                }
                else if (levelMap[i, j] == 4)
                {
                    //GameObject game = Instantiate<GameObject>(gameObjects[3]);
                    //game.transform.parent = back[3].transform;
                    //game.transform.position = new Vector3(-4f + j * 0.5f, 4f-i * 0.5f, 0);


                }
                else if (levelMap[i, j] == 5)
                {
                    //GameObject game = Instantiate<GameObject>(gameObjects[4]);
                    //game.transform.parent = back[4].transform;
                    //game.transform.position = new Vector3(-4f + j * 0.5f, 4f-i * 0.5f, 0);
                    listgame.Add(new Vector3(-4f + j * 0.5f, 4f - i * 0.5f, 0));
                    listgamecount++;

                }
                else if (levelMap[i, j] == 6)
                {
                    //GameObject game = Instantiate<GameObject>(gameObjects[5]);
                    //game.transform.parent = back[5].transform;
                    //game.transform.position = new Vector3(-4f + j * 0.5f, 4f-i * 0.5f, 0);


                }
                else if (levelMap[i, j] == 7)
                {
                    //GameObject game = Instantiate<GameObject>(gameObjects[6]);
                    //game.transform.parent = back[6].transform;
                    //game.transform.position = new Vector3(-4f + j * 0.5f, 4f-i * 0.5f, 0);


                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getP(Vector3 vector)
    {
        for (int i = 0; i < 30; ++i)
        {
            for (int j = 0; j < 28; ++j)
            {
                if (vector.x >= (float)(-4f + 0.5 * j - 0.25f) && vector.x <= (float)(-4f + 0.5 * j + 0.25f)
                    && vector.y >= (float)(4 - 0.5 * i - 0.25f) && vector.y <= (float)(4 - 0.5 * i + 0.25f))
                {
                    return new Vector3(i, j, 0);
                }
            }
        }

        return new Vector3(0, 0, 0);

    }

    public List<int> getList(Vector3 vector3)
    {
        Vector3 vector31 = new Vector3(0, 0, 0);
        vector31 = getP(vector3);
        //Debug.Log("vec:" + vector31);
        List<int> ss = new List<int>();

        if (((int)(vector31.y - 1))>=0&&((int)(vector31.x))>=0)
        {
            if (levelMap[(int)(vector31.x), (int)(vector31.y - 1)] == 5 ||
            levelMap[(int)(vector31.x), (int)(vector31.y - 1)] == 0)
            {
                ss.Add(0);
                //return 0;
            }
        }
        if (((int)(vector31.y + 1) < 28))
        {
            if ((levelMap[(int)(vector31.x), (int)(vector31.y + 1)] == 5 ||
            levelMap[(int)(vector31.x), (int)(vector31.y + 1)] == 0))
            {
                //return 1;
                ss.Add(1);
            }

        }
        if ((int)(vector31.x - 1)>0)
        {
            if (levelMap[(int)(vector31.x - 1), (int)(vector31.y)] == 5 ||
           levelMap[(int)(vector31.x - 1), (int)(vector31.y)] == 0)
            {
                ss.Add(2);
                //return 2;
            }
        }
        if (((int)(vector31.x + 1) < 30))
        {
            if ((levelMap[(int)(vector31.x + 1), (int)(vector31.y)] == 5 ||
           levelMap[(int)(vector31.x + 1), (int)(vector31.y)] == 0))
            {
                ss.Add(3);
                //return 3;
            }

        }

        return ss;
    }
}
