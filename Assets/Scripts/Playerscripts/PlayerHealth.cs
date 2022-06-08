using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static float pHealth;
    public static float maxHealth = 1000;
    float filSpeed;

    public Image healthBar;

    void Start()
    {
        pHealth = maxHealth;
    }

    void Update()
    {
        filSpeed = 3f * Time.deltaTime;

        if (pHealth < 0)
        {
            sceneAI.dead = true;
            Debug.Log("player dead");
        }

        HealthBarFiller();
        ColourChange();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, pHealth / maxHealth, filSpeed);
    }

    void ColourChange()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (pHealth / maxHealth));
        healthBar.color = healthColor;
    }
}
