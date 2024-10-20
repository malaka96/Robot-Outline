using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool canPauseMenu;
    private bool isPaused = false;

    [SerializeField] private GameObject pauseMenu;
   

    private void Start()
    {
        canPauseMenu = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPauseMenu)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
      
        DrawManager._drawingStop = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        DrawManager._drawingStop = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
