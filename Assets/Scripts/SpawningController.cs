using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{
    [SerializeField] List<GameObject> BlueEnemies;
    [SerializeField] List<GameObject> RedEnemies;
    [SerializeField] List<GameObject> BlueBosses;
    [SerializeField] List<GameObject> RedBosses;
    [SerializeField] Vector2 spawningArea;
    [SerializeField] float spawningTimer;
    [SerializeField] GameObject player;
    private PlayerController playerController;
    float timer;

    int RedUpgrades;
    int BlueUpgrades;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        BlueUpgrades = playerController.Blue_CadenceLvl + playerController.Blue_DamageLvl;
        RedUpgrades = playerController.Red_CadenceLvl + playerController.Red_DamageLvl;
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawningTimer;
        }
        
        //Actualizamos la cantidad de mejoras del player
        BlueUpgrades = playerController.Blue_CadenceLvl + playerController.Blue_DamageLvl;
        RedUpgrades = playerController.Red_CadenceLvl + playerController.Red_DamageLvl;
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy;

        //Numero aleatorio de la lista de enemigos
        int random = UnityEngine.Random.Range(0, BlueEnemies.Count);

        if (BlueUpgrades > RedUpgrades) //Si + mejoras Azules 2/3 de sacar Rojos
        {
            if (UnityEngine.Random.Range(0, 3) > 1) 
            {
                newEnemy = Instantiate(BlueEnemies[random]);
            }
            else
            {
                newEnemy = Instantiate(RedEnemies[random]);
            }
        }
        else if (BlueUpgrades < RedUpgrades)//Si + mejoras Rojas 2/3 de sacar Azules
        {
            if (UnityEngine.Random.Range(0, 3) > 1)
            {
                newEnemy = Instantiate(RedEnemies[random]);
            }
            else
            {
                newEnemy = Instantiate(BlueEnemies[random]);
            }
        }
        else //Sino 50/50 
        {
            if (UnityEngine.Random.Range(0,2) > 0)
            {
                newEnemy = Instantiate(BlueEnemies[random]);
            }
            else
            {
                newEnemy = Instantiate(RedEnemies[random]);
            } 
        }

        //Creamos una posicion
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;
        newEnemy.transform.position = position;
        //Le indicamos el target
        newEnemy.GetComponent<EnemigoController>().SetTarget(player);
        //Lo hacemos hijo de nuestro contenedor de enemigos
        newEnemy.transform.parent = transform;
    }

    public void SpawnBoss()
    {
        GameObject boss;
        int random = UnityEngine.Random.Range(0, BlueBosses.Count);

        if (BlueUpgrades > RedUpgrades) //Si + mejoras Azules 2/3 de sacar Rojos
        {
            if (UnityEngine.Random.Range(0, 3) > 1)
            {
                boss = Instantiate(BlueBosses[random]);
            }
            else
            {
                boss = Instantiate(RedBosses[random]);
            }
        }
        else if (BlueUpgrades < RedUpgrades)//Si + mejoras Rojas 2/3 de sacar Azules
        {
            if (UnityEngine.Random.Range(0, 3) > 1)
            {
                boss = Instantiate(RedBosses[random]);
            }
            else
            {
                boss = Instantiate(BlueBosses[random]);
            }
        }
        else //Sino 50/50 
        {
            if (UnityEngine.Random.Range(0, 2) > 0)
            {
                boss = Instantiate(BlueBosses[random]);
            }
            else
            {
                boss = Instantiate(RedBosses[random]);
            }
        }

        //Creamos una posicion
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;
        boss.transform.position = position;
        //Le indicamos el target
        boss.GetComponent<EnemigoController>().SetTarget(player);
        //Lo hacemos hijo de nuestro contenedor de enemigos
        boss.transform.parent = transform;
    }

    //Genera una posicion aleatoria al rededor del jugador
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        //Genera una posicion random al rededor de la zona de spawneao que le he especificado (Fuera de la camara)
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

    //Escala el tiempo entre spawns de enemigos
    public void ScalingSpawnTime()
    {
        spawningTimer -= 0.1f;
        if (spawningTimer < 0.5)
        {
            spawningTimer = 0.5f;
        }
    }
}
