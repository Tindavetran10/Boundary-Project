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

        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.enemyKilled += OnEnemyKilled; // L?ng nghe s? ki?n Enemy ch?t
        }
    }

    void OnDestroy()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.enemyKilled -= OnEnemyKilled; // H?y ??ng ký khi object b? h?y
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
                questText.text = "Kill 5 Gobble's Eggs (0/5)";
            }
        }
    }

    void OnEnemyKilled(EnemyRace enemyType)
    {
        if (!questStarted) return;

        // Ch? c?ng ?i?m n?u k? ??ch là GobbleEgg
        if (enemyType == EnemyRace.Gobbler)
        {
            eggsDestroyed++;

            if (questText != null)
            {
                questText.text = $"Kill 5 Gobble's Eggs ({eggsDestroyed}/{eggsRequired})";
            }

            if (eggsDestroyed >= eggsRequired)
            {
                CompleteQuest();
            }
        }
    }

    void CompleteQuest()
    {
        if (questText != null)
        {
            questText.text = "Nhi?m v? hoàn thành!Complete";
        }
        if (reward != null)
        {
            reward.SetActive(true); // Hi?n th? ph?n th??ng
        }
    }
}
