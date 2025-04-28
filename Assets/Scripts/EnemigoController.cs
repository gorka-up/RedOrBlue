using System;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] Transform objetivo;
    GameObject targetGameObject;
    [SerializeField] private float Speed;

    Rigidbody rb;

    [SerializeField] private double Health = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        objetivo = target.transform;
    }

    void FixedUpdate()
    {
        //Sigue al personaje a la velocidad speed
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, Speed*Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attacking the player");
    }

    public void TakeDamage(double damage)
    {
        Health -= damage;
        Debug.Log(Health);
        if (Health <= 0)
        {
            DropXP();
            // Verifica si es una instancia en escena
            if (gameObject.scene.IsValid())
            {
                Destroy(gameObject); // Destruye la instancia
            }
            else
            {
                Debug.LogWarning("No se puede destruir un Prefab directamente.");
            }
        }
    }

    void DropXP()
    {
        //Aqui suelta los puntos
        //Destroy(gameObject);
    }
}
