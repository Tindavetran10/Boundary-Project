using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    public DialogData dialogData;
    public DialogManager dialogManager;

    private bool isInteracting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = true;
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
        if (isInteracting && Input.GetKeyDown(KeyCode.G))
        {
            dialogManager.ShowMessage(dialogData);
        }
    }
}
