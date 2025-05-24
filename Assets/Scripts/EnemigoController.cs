using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] public double Health;
    [SerializeField] public float Speed;

    [SerializeField] public Transform objetivo;
    public GameObject targetGameObject;
    private PlayerController playerController;

    [SerializeField] public GameObject particlePrefab;

    [SerializeField] public GameObject soundEfect;

    public bool damageTaken;

    private Rigidbody2D rb;

    private void Start()
    {
        playerController = targetGameObject.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
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
        playerController.XP +=(int)(100.0 * playerController.Greed);

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
        
    }
}
