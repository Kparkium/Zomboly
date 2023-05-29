using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour 
{
    //Fields (these are default private)
    public int _currentHealth;
    public int _currentMaxHealth;
    public ParticleSystem hitParticle;
    public void Start()
    {
        StartCoroutine(healthTick());
    }

    //Properties
    //You use these to change and update the fields instead of directly changing the fields.
    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    //Constructor
    public void init(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    //Methods

    //use this method when an unit is damaged.
    public void DamageUnit(int dmgAmount)
    {

        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
            StartCoroutine(DamageParticles());
        }
        if(_currentHealth <= 0)
        {
            DestroyImmediate(this.gameObject);
        }
    }

    public void HealUnit(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }

        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }

    private IEnumerator healthTick()
    {
        yield return new WaitForSeconds(2);
        HealUnit(1);
        StartCoroutine(healthTick());
    }

    private IEnumerator DamageParticles()
    {
        ParticleSystem particles = Instantiate(hitParticle, this.gameObject.transform.position, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(2);
        if(this != null)
        {
            Destroy(particles);
        }
    }
}
