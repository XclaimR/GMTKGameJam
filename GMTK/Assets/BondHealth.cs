using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BondHealth : MonoBehaviour
{
    float bondHealth = 3f;
    float timeOut = 1f;
    float lastTime = 0f;
    public void RegainHealth()
    {
        bondHealth++;
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
