using UnityEngine;

public class ShootEnemyController : MonoBehaviour
{
    Rigidbody rb;

    public GameObject bullet;
    public Transform bulletPos;
    private float bulletTimer;


    [SerializeField] float ViewDistance;
    [SerializeField] float shootTimer;

    EnemigoController enemigoController;
    PlayerController playerController;
    [SerializeField] GameObject player;

    [SerializeField] public GameObject soundEfect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemigoController = GetComponent<EnemigoController>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
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
        playerController.GetHurt();
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, enemigoController.objetivo.position);
        if (distance < ViewDistance)
        {
            bulletTimer = bulletTimer + Time.deltaTime;
            if (bulletTimer > shootTimer)
            {
                bulletTimer = 0;
                Shoot();
            }
        }
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, enemigoController.objetivo.position, enemigoController.Speed * Time.deltaTime);
        }
    }
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Instantiate(soundEfect);
    }
}