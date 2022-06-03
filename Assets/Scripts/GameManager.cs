using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject scoreKeeper;
    public static int score = 0;
    public GameObject sheepHerd;
    public GameObject pauseText;
    public static GameObject net;
    public GameObject player;

    private void Awake()
    {
        //static objects cant be changed in unity editor
        net = player;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            ShowPauseMenu();
        }
        scoreKeeper.GetComponent<Text>().text = "Score: " + score;
        if (sheepHerd.GetComponent<Flock>().agents.Count == 0 && !pauseMenu.activeSelf)
        {
            ShowPauseMenu();
            pauseText.GetComponent<Text>().text = "Score: " + GameManager.score;
        }
    }
    void ShowPauseMenu()
    {
        //pause and unpause game
        gameObject.GetComponent<GMenuScript>().PauseUnPause();
        //open and close menu
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void ResetScore()
    {
        GameManager.score = 0;
    }
}
