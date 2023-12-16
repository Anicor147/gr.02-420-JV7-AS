using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    private int extraHealth;

    public void modifyHealth(int value)
    {
        if (value < 0 && extraHealth > 0)
        {
            if (Mathf.Abs(value) > extraHealth)
            {
                extraHealth = 0;
                value = -(Mathf.Abs(value) - extraHealth);
            }
            else extraHealth += value;
        }

        else currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        //add UI update line
        
        
    }

    void GainExtraHealth(int value)
    {
        extraHealth += value;
        //ad UI update line
    }
}
