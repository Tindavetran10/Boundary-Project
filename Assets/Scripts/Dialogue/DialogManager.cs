using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TMP_Text text;
    public GameObject DialogSystem;
    string[] words;
    int number;

    public void ShowMessage(DialogData dialogData)
    {
        number = 0;
        words = dialogData.dialogLines;
        DialogSystem.SetActive(true);
        Skip();
    }
    
    public void Skip()
    {
        if(number < words.Length)
        {
            text.text = words[number];
            number += 1;
        }
        else
        {
            number = 0;
            DialogSystem.SetActive(false);
        }
    }
}
