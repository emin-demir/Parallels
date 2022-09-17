using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{


    //Heath
    public Slider healthslider;
    public void SetMaxHealth(float health)
    {
        healthslider.maxValue = health;
        healthslider.value = health;

    }
    public void SetHealth(float health)
    {
        healthslider.value = health;

    }

    //Stamina
    public Slider staminaslider;
    public void SetMaxStamina(float stamina)
    {
        staminaslider.maxValue = stamina;
        staminaslider.value = stamina;

    }
    public void SetStamina(float stamina)
    {
        staminaslider.value = stamina;

    }

    //Dash
    public Slider dashslider;
    public void SetMaxDash(float dash)
    {
        dashslider.maxValue = dash;
        dashslider.value = dash;

    }
    public void SetDash(float dash)
    {
        dashslider.value = dash;

    }



}
