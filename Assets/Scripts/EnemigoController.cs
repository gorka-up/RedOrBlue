using System;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] public BasicRedEnemyController BasicRedEnemyController;

    public void TakeDamage(double damage)
    {
        BasicRedEnemyController.Health -= damage;
        Debug.Log(BasicRedEnemyController.Health);
        if (BasicRedEnemyController.Health <= 0)
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
}
