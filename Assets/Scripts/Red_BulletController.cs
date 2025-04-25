using UnityEngine;

public class Red_BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private EnemigoController EnemyController;

    private PlayerController playerController;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

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
                    EnemyController.TakeDamage(playerController.Damage);
                    Destroy(gameObject);
                    break;
                }
        }
    }
}
