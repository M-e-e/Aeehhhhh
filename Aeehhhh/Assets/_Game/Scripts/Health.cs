using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class Health : MonoBehaviour, IDamageAble
{
    [SerializeField] private GameObjectAction deathAction;
    
    [SerializeField] private IntReference maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void GetDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Debug.Log("DEATH OF " + gameObject.name);
            deathAction.Do(gameObject);
        }
    }
}
