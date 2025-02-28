using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerHealthUnit _playerHealth = new PlayerHealthUnit(2680, 2680);

    public PlayerManaUnit _playerMana = new PlayerManaUnit(1580, 1580);

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
}
