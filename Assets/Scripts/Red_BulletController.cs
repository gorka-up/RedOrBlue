using UnityEngine;

public class Red_BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private EnemigoController EnemyController;

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Wall":
                {
                    Destroy(gameObject);
                    break;
                }
            case "Red_Enemy":
                {
                    EnemyController.TakeDamage(1);
                    Destroy(gameObject);
                    break;
                }
        }
    }
}
