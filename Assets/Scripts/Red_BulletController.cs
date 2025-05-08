using UnityEngine;

public class Red_BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private PlayerController playerController;

    private EnemigoController enemigoController;

    [SerializeField] public GameObject particlePrefab;

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
                    Instantiate(particlePrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;
                }
            case "Red_Enemy":
                {
                    Instantiate(particlePrefab, transform.position, Quaternion.identity);
                    enemigoController = collision.gameObject.GetComponent<EnemigoController>();
                    enemigoController.TakeDamage(playerController.Damage);
                    Destroy(gameObject);
                    break;
                }
            case "Blue_Enemy":
                {
                    Destroy(gameObject);
                    break;
                }
        }
    }
}
