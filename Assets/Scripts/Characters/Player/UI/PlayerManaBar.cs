using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour
{
    [SerializeField] Slider _manaSlider;

    /*
    void Start()
    {
        _manaSlider = GetComponent<Slider>();
    }*/

    public void SetMaxMana(float maxMana)
    {
        _manaSlider.maxValue = maxMana;
        _manaSlider.value = maxMana;
    }

    public void SetMana(float mana)
    {
        _manaSlider.value = mana;
    }
}
