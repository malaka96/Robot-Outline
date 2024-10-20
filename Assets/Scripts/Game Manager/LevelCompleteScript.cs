using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    [SerializeField] private GameObject _levelComplete;
    [SerializeField] private GameObject _inGameUI;

    [SerializeField] private int saveSceneIndex;
    [SerializeField] private int _nextLevelIndex;

    public DrawManager drawManager;
   
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("ToLoadScene", saveSceneIndex);
            drawManager.ClearOldLines();
            DrawManager._drawingStop = true;
            PauseMenu.canPauseMenu = false;
            Time.timeScale = 0f;
            _inGameUI.SetActive(false);
            _levelComplete.SetActive(true);
        }
    }

    public void Tester()
    {
        Debug.Log("Hello");
    }

    public  void NwxtLevel()
    {   
        
        PauseMenu.canPauseMenu = true;
        SceneManager.LoadScene(_nextLevelIndex);
    }
}
