using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject CrossFade;

    public GameObject MenuCanvas;

    public CursonVisible cursonVisible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(1);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        Debug.Log(sceneName);
        Debug.Log("Bat Dau Chuyen scene");
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        MenuCanvas.SetActive(true);
        cursonVisible.isPauseGame = true;
    }

    public void ContinueTheScene()
    {
        MenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        cursonVisible.isPauseGame = false;
    }

    public void BackToMenu()
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(0);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        Debug.Log(sceneName);
        Debug.Log("Bat Dau Chuyen scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
