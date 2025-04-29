using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float bulletForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletForce;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
