using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private int xPos;
    private int yPos;
    public int enemyCount = 0;
    public GameObject enemy;

    private void Update()
    {
        StartCoroutine(EnemySpawn());
        Debug.Log(enemyCount);
    }

    IEnumerator EnemySpawn()
    {
        while (enemyCount <= 3)
        {
            xPos = Random.Range(-22, 23);
            yPos = Random.Range(0, 10);
            Instantiate(enemy, new Vector2(xPos, yPos),Quaternion.identity).transform.localScale = Vector2.one * 0.05f;
            yield return new WaitForSeconds(0.1f);
            enemyCount++;
        }
    }
}
