using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] Vector2 spawningArea;
    [SerializeField] float spawningTimer;
    [SerializeField] GameObject player;
    float timer;

    [SerializeField] List<float> spawningWeights; // Pesos para cada enemigo
    private List<float> cumulativeWeights;
    private float totalWeight;

    //private void Start()
    //{
    //    InitializeWeights();
    //}

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

        //GameObject newEnemy = SelectWeightedEnemy();

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

    //void InitializeWeights()
    //{
    //    // Si no hay pesos definidos, crear unos por defecto (1)
    //    if (spawningWeights == null || spawningWeights.Count != enemies.Count)
    //    {
    //        spawningWeights = new List<float>();
    //        foreach (var enemy in enemies)
    //        {
    //            spawningWeights.Add(1f); // Peso por defecto 1
    //        }
    //    }

    //    // Calcular pesos acumulativos
    //    cumulativeWeights = new List<float>();
    //    totalWeight = 0f;

    //    for (int i = 0; i < spawningWeights.Count; i++)
    //    {
    //        totalWeight += spawningWeights[i];
    //        cumulativeWeights.Add(totalWeight);
    //    }
    //}

    //GameObject SelectWeightedEnemy()
    //{
    //    if (enemies.Count == 0) return null;
    //    if (enemies.Count == 1) return enemies[0];

    //    // Generar un valor aleatorio dentro del rango total
    //    float randomValue = UnityEngine.Random.Range(0f, totalWeight);

    //    // Encontrar el indice correspondiente
    //    for (int i = 0; i < cumulativeWeights.Count; i++)
    //    {
    //        if (randomValue <= cumulativeWeights[i])
    //        {
    //            return enemies[i];
    //        }
    //    }

    //    return enemies[enemies.Count - 1]; // Por defecto, el ultimo
    //}

    // Metodo para cambiar pesos dinamicamente
    //public void SetEnemyWeight(int enemyIndex, float newWeight)
    //{
    //    if (enemyIndex >= 0 && enemyIndex < spawningWeights.Count)
    //    {
    //        spawningWeights[enemyIndex] = newWeight;
    //        // Recalcular pesos acumulativos
    //        InitializeWeights();
    //    }
    //}
}
