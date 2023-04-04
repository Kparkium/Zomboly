using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public UnitHealth targetHealth = new UnitHealth(100,100);

    public void TakeDamage(int damage)
    {
        targetHealth.DamageUnit(damage);
        if(targetHealth.Health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
        // Add particle death anim here
    }
}
