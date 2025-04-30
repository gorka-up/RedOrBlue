using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float bulletForce;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletForce;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                {
                    Destroy(gameObject);
                    break;
                }
            case "Player":
                {
                    playerController.GetHurt();
                    Destroy(gameObject);
                    break;
                }
        }
    }
}
