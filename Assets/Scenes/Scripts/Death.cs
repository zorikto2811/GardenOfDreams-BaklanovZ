using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] Slider healthBar;
    [SerializeField] private Text deathBar;
    [SerializeField] private GameObject currentObject;
    public GameObject dropItem;
    private bool isDead;
    private const float startTime = 1.0f;
    private float deathTimer;

    private void Start()
    {
        deathTimer = startTime;
    }

    private void Update()
    {
        healthBar.value = health.currentHealth;

        if (isDead)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
                currentObject.SetActive(false);
            Instantiate(dropItem, currentObject.transform.position, Quaternion.identity).transform.localScale = Vector2.one * 8;
        }
    }
    public void CheckIsAlive(float currentHealth)
    {
        if (currentHealth <= 0)
        {
            if (currentObject.CompareTag("Enemy"))
            {
                currentObject.GetComponent<CircleCollider2D>().enabled = false;
            }
            healthBar.gameObject.SetActive(false);
            deathBar.gameObject.SetActive(true);
            isDead = true;
        }

    }
}
