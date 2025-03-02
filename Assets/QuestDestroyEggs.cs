using TMPro;
using UnityEngine;

public class QuestDestroyEggs : MonoBehaviour
{
    public int eggsRequired = 5;
    private int eggsDestroyed = 0;
    public TMP_Text questText; // S? d?ng TextMeshPro UGUI
    public GameObject questPanel; // Panel ch?a questText
    public GameObject reward; // Ph?n th??ng khi hoàn thành nhi?m v?

    private bool questStarted = false;

    void Start()
    {
        if (questPanel != null)
        {
            questPanel.SetActive(false); // ?n panel khi m?i vào game
        }
    }

    public void StartQuest()
    {
        if (!questStarted)
        {
            questStarted = true;
            if (questPanel != null)
            {
                questPanel.SetActive(true); // Hi?n panel khi nh?n nhi?m v?
            }
            if (questText != null)
            {
                questText.text = "Kill Gobbles (0/5)";
            }
        }
    }

    // G?i hàm này khi m?t qu? tr?ng Gobble b? phá h?y
    public void DestroyEgg()
    {
        if (!questStarted) return;

        eggsDestroyed++;

        if (questText != null)
        {
            questText.text = $"Kill Gobbles (0/5) ({eggsDestroyed}/{eggsRequired})";
        }

        if (eggsDestroyed >= eggsRequired)
        {
            CompleteQuest();
        }
    }

    void CompleteQuest()
    {
        if (questText != null)
        {
            questText.text = "Completed";
        }
        if (reward != null)
        {
            reward.SetActive(true); // Hi?n th? ph?n th??ng
        }
    }
}
