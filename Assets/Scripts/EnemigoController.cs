using System;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] public double Health = 10;
    [SerializeField] public float Speed = 3.5f;

    [SerializeField] public Transform objetivo;
    public GameObject targetGameObject;
    private PlayerController playerController;

    [SerializeField] public GameObject particlePrefab;

    [SerializeField] public GameObject soundEfect;

    private void Start()
    {
        playerController = targetGameObject.GetComponent<PlayerController>();
    }
    public void TakeDamage(double damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            DropXP();
        }
    }

    void DropXP()
    {
        Instantiate(soundEfect);
        //Aqui suelta los puntos
        playerController.XP +=(int)(100.0 * playerController.Greed);

        Instantiate(particlePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        objetivo = target.transform;
    }

    int ScalingStats()
    {
        return 1;
    }
}
