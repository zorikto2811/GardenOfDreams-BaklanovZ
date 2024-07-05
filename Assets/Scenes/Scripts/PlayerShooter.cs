using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPos;
    public int fireSpeed;
    private GameObject currentBullet;
    public bool isClick;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (isClick)
            { 
                Shoot();
            }
                
        }
    }

    public void Shoot()
    {
        isClick = true;
        currentBullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        currentBulletVelocity.velocity = new Vector2(currentBulletVelocity.velocity.x, fireSpeed);
    }
}
