
using UnityEngine;

public class Enemy_Respawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] respawnPoints;
    [SerializeField] private Transform player;
    [SerializeField] private float cooldown = 2f;
    [Space]
    [SerializeField] private float cooldownDecreaseRate = .05f;

    private float timer;
    private int enemyCount = 30;

    private void Update()
    {
        timer -= Time.deltaTime;    

        if (timer < 0)
        {
            timer = cooldown;
            if (enemyCount > 0)
            {
                CreateNewEnemy();
                enemyCount--;
            }

            cooldown = Mathf.Max(cooldown, cooldown -  cooldownDecreaseRate);
        }
    }

    private void CreateNewEnemy()
    {
        int respawnPointIndex = Random.Range(0,respawnPoints.Length);
        Vector3 spawnPoint = respawnPoints[respawnPointIndex].position;


        if (player != null)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            bool createdOnTheRight = newEnemy.transform.position.x > player.transform.position.x;

            if (createdOnTheRight)
                newEnemy.GetComponent<Enemy>().Flip();
        }

    }
}
