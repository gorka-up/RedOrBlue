using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{    
    Rigidbody rb;

    EnemigoController enemigoController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemigoController = GetComponent<EnemigoController>();
    }

    void FixedUpdate()
    {
        //Sigue al personaje a la velocidad speed
        transform.position = Vector2.MoveTowards(transform.position, enemigoController.objetivo.position, enemigoController.Speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == enemigoController.targetGameObject)
        {
            Attack();
        }
    }


    private void Attack()
    {
        Debug.Log("Attacking the player");
    }
}
