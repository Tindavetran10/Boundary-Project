using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    public DialogData dialogData; // Tham chi?u ??n DialogData c?a NPC
    public DialogManager dialogManager; // Tham chi?u ??n DialogManager

    private bool isInteracting = false; // Ki?m tra xem ng??i ch?i có ? g?n không

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered NPC collider");
        if (other.CompareTag("Player")) // Thay "Player" b?ng tag c?a nhân v?t
        {
            isInteracting = true;
            Debug.Log("isInteracting is now true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = false;
        }
    }
    private void Update()
    {
        if (isInteracting && Input.GetKeyDown(KeyCode.E)) // Tùy ch?nh phím t??ng tác (ví d?: E)
        {
            Debug.Log("Key is pressed");
            dialogManager.ShowMessage(dialogData);
        }
    }
}
