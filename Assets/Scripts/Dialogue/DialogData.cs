using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogData", menuName = "Game Data/Dialog Data")]
public class DialogData : ScriptableObject
{
    [TextArea(3, 10)] // Cho phép nh?p v?n b?n nhi?u dòng
    public string[] dialogLines;
}