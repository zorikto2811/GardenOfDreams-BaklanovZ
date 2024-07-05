using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShoot : MonoBehaviour
{
    public float damage;
    public LayerMask enemyLayer;
    [Range(0,1)] public float radius;
    public Transform attackPos;
    public GameObject bullet;

    void Update()
    {
        Damager();
    }

    private void Damager()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, radius, enemyLayer);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Health>().TakeDamage(damage);
            Destroy(bullet);
        }
    }
}
