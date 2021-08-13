using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Healthbar : MonoBehaviour
{

    public Slider m_HealthBarSlider;

    public void SetMaxHealth(int i_MaxHealth)
    {
        m_HealthBarSlider.maxValue = i_MaxHealth;
        m_HealthBarSlider.minValue = 10;
        m_HealthBarSlider.value = i_MaxHealth;
    }

    public void SetHealth(int i_Health)
    {
        m_HealthBarSlider.value = i_Health;
    }
}
