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

    private void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        bondHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        }
        
    }

    public void LoseHealth()
    {
        if(Time.time > lastTime)
        {
            bondHealth--;
            healthBar.SetHealth(bondHealth);
            Debug.Log("Life Lost" + ReturnHealth() );
            lastTime = Time.time + timeOut;
        }
    }

    public float ReturnHealth()
    {
        return bondHealth;
    }
}
