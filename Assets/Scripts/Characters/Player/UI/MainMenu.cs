using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject CrossFade;

    public GameObject MenuCanvas;

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
        ScencesManage.Instance.LoadScene(sceneName, CrossFade.name);
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        MenuCanvas.SetActive(true);
        
    }

    public void ContinueTheScene()
    {
        MenuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(0);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        Debug.Log(sceneName);
        Debug.Log("Bat Dau Chuyen scene");
        ScencesManage.Instance.LoadScene(sceneName, CrossFade.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
