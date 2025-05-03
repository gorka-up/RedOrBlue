using UnityEngine;

public class ShootEnemyController : MonoBehaviour
{
    Rigidbody rb;

    //[SerializeField] private double Health;

    public GameObject bullet;
    public Transform bulletPos;
    private float bulletTimer;


    [SerializeField] float ViewDistance;

    EnemigoController enemigoController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemigoController = GetComponent<EnemigoController>();
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
    void Update()
    {
        float distance = Vector2.Distance(transform.position, enemigoController.objetivo.position);
        if (distance < ViewDistance)
        {
            bulletTimer = bulletTimer + Time.deltaTime;
            if (bulletTimer > 2)
            {
                bulletTimer = 0;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}