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

    private void Awake()
    {
        bondHealth = maxHealth;
    }
    public void RegainHealth()
    {
        if(bondHealth < maxHealth && !isDead)
        {
            if(Time.time > lastRegenTime)
            {
                bondHealth += regenerationRate;
                lastRegenTime = Time.time + regenerationRate;
            }
        }
        
    }

    public void LoseHealth()
    {
        if(Time.time > lastTime)
        {
            bondHealth--;
            Debug.Log("Life Lost" + ReturnHealth() );
            lastTime = Time.time + timeOut;
        }
    }

    public float ReturnHealth()
    {
        return bondHealth;
    }
}
