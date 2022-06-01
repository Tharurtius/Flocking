using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            //pause and unpause game
            gameObject.GetComponent<GMenuScript>().PauseUnPause();
            //open and close menu
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

}
