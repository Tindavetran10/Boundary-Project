using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursonVisible : MonoBehaviour
{
    public bool isPauseGame;

    private void Start()
    {
        isPauseGame = false;
    }

    private void Update()
    {
        if (isPauseGame == true)
        {
            UnLockTheCursor();
            Debug.Log("Trang thai tro chuot: " + Cursor.visible);
            Debug.Log("Tam dung game");
        }
        
        if (isPauseGame == false)
        {
            LockTheCursor();
            Debug.Log("Trang thai tro chuot: " + Cursor.visible);
            Debug.Log("Tiep tuc choi");
        }
    }

    public void LockTheCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnLockTheCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
