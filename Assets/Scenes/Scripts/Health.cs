using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private Death death;

    private void Awake()
    {
        currentHealth = maxHealth;
        death = GetComponent<Death>();

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        death.CheckIsAlive(currentHealth);
    }
}

