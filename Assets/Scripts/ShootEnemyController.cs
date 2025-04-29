using UnityEngine;

public class ShootEnemyController : MonoBehaviour
{
    [SerializeField] Transform objetivo;
    GameObject targetGameObject;
    [SerializeField] private float Speed;

    Rigidbody rb;

    [SerializeField] private double Health = 10;

    public GameObject bullet;
    public Transform bulletPos;
    private float bulletTimer;


    [SerializeField] float ViewDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        objetivo = target.transform;
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
    void Update()
    {
        float distance = Vector2.Distance(transform.position, objetivo.position);
        while (distance < ViewDistance)
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
