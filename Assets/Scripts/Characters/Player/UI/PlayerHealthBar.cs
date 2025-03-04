using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Slider _healthSlider;

    // Start is called before the first frame update
    /*void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }*/

    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        _healthSlider.value = health;
    }
}
