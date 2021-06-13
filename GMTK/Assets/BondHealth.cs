using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BondHealth : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 3f;
    float bondHealth;
    float timeOut = 1f;
    float lastTime = 0f;
    float regenerationAmount = 0.1f;
    float regenerationRate = 0.1f;
    float lastRegenTime = 0f;
    public bool isDead = false;
    HealthBar healthBar;
    AudioSource audio;

    private void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        bondHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audio = GetComponent<AudioSource>();
    }
    public void RegainHealth()
    {
        if (Time.time > lastRegenTime)
        {
            if (bondHealth < maxHealth && !isDead)
            {
                bondHealth += regenerationRate;
                lastRegenTime = Time.time + regenerationRate;
                healthBar.SetHealth(bondHealth);
            }
            if(bondHealth > maxHealth)
            {
                bondHealth = maxHealth;
            }
        }
        
    }

    public void LoseHealth(float val)
    {
        if(Time.time > lastTime)
        {
            audio.Play();
            bondHealth -= val;
            healthBar.SetHealth(bondHealth);
            lastTime = Time.time + timeOut;
        }
        if(bondHealth <= 0)
        {
            isDead = true;
        }
    }

    public float ReturnHealth()
    {
        return bondHealth;
    }
}
