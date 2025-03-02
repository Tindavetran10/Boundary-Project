using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class DialogManager : MonoBehaviour
{
    [FormerlySerializedAs("text")]
    public TMP_Text Text;
    public GameObject DialogSystem;
    public Button acceptQuestButton; // Thêm nút nh?n nhi?m v?

    [SerializeField]
    private TextScrollingEffect _effect;

    private string[] _words;
    private int _currentLine;
    private bool questAvailable = false;

    public QuestDestroyEggs questScript; // Tham chi?u ??n script nhi?m v?

    public void ShowMessage(DialogData dialogData)
    {
        _currentLine = 0;
        _words = dialogData.dialogLines;
        DialogSystem.SetActive(true);
        Skip();
    }

    public void Skip()
    {
        if (_currentLine < _words.Length)
        {
            _effect.Play(_words[_currentLine], 5);

            // Ki?m tra n?u là câu tho?i th? 2 thì hi?n th? nút nh?n nhi?m v?
            if (_currentLine == 1)
            {
                acceptQuestButton.gameObject.SetActive(true);
                questAvailable = true;
            }
            else
            {
                acceptQuestButton.gameObject.SetActive(false);
            }

            _currentLine += 1;
        }
        else
        {
            _currentLine = 0;
            DialogSystem.SetActive(false);
            acceptQuestButton.gameObject.SetActive(false);
        }
    }

    // Hàm ?? nh?n nhi?m v? khi nh?n nút
    public void AcceptQuest()
    {
        if (questAvailable)
        {
            questScript.StartQuest(); // B?t ??u nhi?m v? phá tr?ng Gobble
            acceptQuestButton.gameObject.SetActive(false);
            DialogSystem.SetActive(false);
        }
    }
}
