using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _inGameUiCanvas;
    [SerializeField] private int _activeSceneIndex;
    [SerializeField] private GameObject _showLevel;
    [SerializeField] private TMP_Text _fpsText;
    public DrawManager drawManager;
    private float deltaTime = 0.0f;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Time.timeScale = 1f;

        StartCoroutine(ShowLevel());

    }


    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        _fpsText.text = Mathf.Ceil(fps).ToString();
    }

    public void GameOver()
    {
        drawManager.ClearOldLines();
        DrawManager._drawingStop = true;
        PauseMenu.canPauseMenu = false;
        _inGameUiCanvas.SetActive(false);
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
       
    }

    public void Restart()
    {
        
        PauseMenu.canPauseMenu = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(_activeSceneIndex);
    }

    IEnumerator ShowLevel()
    {
        yield return new WaitForSeconds(2);
        _showLevel.SetActive(false);
        PauseMenu.canPauseMenu = true;
        DrawManager._drawingStop = false;

    }
}
