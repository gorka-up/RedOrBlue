using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] public double MaxHealth;
    [SerializeField] public double Health;
    [SerializeField] public float Speed;

    [SerializeField] public Transform objetivo;
    public GameObject targetGameObject;
    private PlayerController playerController;
    private ScalingController scalingController;

    [SerializeField] public GameObject particlePrefab;

    [SerializeField] public GameObject soundEfect;

    public bool damageTaken;

    private Rigidbody2D rb;

    [SerializeField] bool IsBoss;

    private void Start()
    {
        playerController = targetGameObject.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        scalingController = transform.parent.gameObject.GetComponent<ScalingController>();
        ScalingStats();
    }
    public void TakeDamage(double damage)
    {
        Health -= damage;
        damageTaken = true;
        if (Health <= 0)
        {
            DropXP();
        }
    }
    private void FixedUpdate()
    {
        rotate();
    }

    void DropXP()
    {
        Instantiate(soundEfect);
        //Aqui suelta los puntos
        if (IsBoss)
        {
            playerController.XP += (int)(250.0 * playerController.Greed * (1 + scalingController.Scalinglevel / 10));
            playerController.TotalXP += (int)(250.0 * playerController.Greed * (1 + scalingController.Scalinglevel / 10));
        }
        else
        {
            playerController.XP += (int)(50.0 * playerController.Greed * (1 + scalingController.Scalinglevel / 10));
            playerController.TotalXP += (int)(50.0 * playerController.Greed * (1 + scalingController.Scalinglevel / 10));
        }
        Instantiate(particlePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        objetivo = target.transform;
    }

    void rotate()
    {
        Vector2 findPlayer= objetivo.position - transform.position;
        float rotateAngle = Mathf.Atan2(findPlayer.y, findPlayer.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = rotateAngle;
    }
    void ScalingStats()
    {
        MaxHealth = MaxHealth * scalingController.Scalinglevel;
        Health = MaxHealth;
    }
}
