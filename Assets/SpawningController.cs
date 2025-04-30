using System;
using UnityEngine;

public class SpawningController : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawningArea;
    [SerializeField] float spawningTimer;
    [SerializeField] GameObject player;
    float timer;

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawningTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<BasicRedEnemyController>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawningArea.x, spawningArea.x);
            position.y = spawningArea.y * f;
        } else {
            position.y = UnityEngine.Random.Range(-spawningArea.y, spawningArea.y);
            position.x = spawningArea.x * f;
        }

        position.z = 0f;

        return position;
    }
}
