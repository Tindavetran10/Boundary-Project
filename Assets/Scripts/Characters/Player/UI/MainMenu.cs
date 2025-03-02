using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        ScencesManage.Instance.LoadScene("Player", "CrossFade");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
