using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonstart : MonoBehaviour
{
    public GameObject score;
    public GameObject gametime;
    // Start is called before the first frame update
    void Start()
    {
        score.transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("score");
        gametime.transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("gametime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void returnButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
