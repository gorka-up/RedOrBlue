using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{
    [SerializeField] GameObject red_enemy;
    [SerializeField] GameObject blue_enemy;
    [SerializeField] List<GameObject> enemies;
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
        //enemy
        int random = UnityEngine.Random.Range(0, enemies.Count);
        GameObject newEnemy = Instantiate(enemies[random]);

        //GameObject newEnemy = (UnityEngine.Random.value < 0.5f) ? Instantiate(red_enemy) : Instantiate(blue_enemy);

        //position
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;
        newEnemy.transform.position = position;
        newEnemy.GetComponent<EnemigoController>().SetTarget(player);
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
