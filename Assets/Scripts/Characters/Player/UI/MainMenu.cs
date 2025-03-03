using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject CrossFade;

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

    public void ExitGame()
    {
        Application.Quit();
    }
}
