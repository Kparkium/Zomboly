using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Needed for UI code

public class StaminaBar : MonoBehaviour
{
    Slider staminaBar;

    private void Start()
    {
        staminaBar = GetComponent<Slider>();
    }

    public void SetMaxStamina(int newMaxStamina)
    {
        staminaBar.maxValue = newMaxStamina;
        staminaBar.value = newMaxStamina;
    }

    public void SetStamina(float stamina)
    {
        staminaBar.value = stamina;
    }
}
