using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage;
    public float attackTimer;
    private float currentTime;
    public bool hasAttack;


    private void Start()
    {
        currentTime = attackTimer;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (currentTime == attackTimer)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
                hasAttack = true;
            }
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = attackTimer;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasAttack = false;
    }
}
