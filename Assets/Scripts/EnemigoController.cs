using System;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] public double Health = 10;
    [SerializeField] public float Speed = 1.5f;

    [SerializeField] public Transform objetivo;
    public GameObject targetGameObject;

    public void TakeDamage(double damage)
    {
        Health -= damage;
        Debug.Log(Health);
        if (Health <= 0)
        {
            DropXP();
        }
    }

    void DropXP()
    {
        //Aqui suelta los puntos
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
