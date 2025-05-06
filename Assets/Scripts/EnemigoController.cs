using System;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] public double Health = 10;
    [SerializeField] public float Speed = 1.5f;

    [SerializeField] public Transform objetivo;
    public GameObject targetGameObject;
    private PlayerController playerController;

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
        //Aqui suelta los puntos
        playerController.XP +=(int)(100.0 * playerController.Greed);
        // Verifica si es una instancia en escena
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
