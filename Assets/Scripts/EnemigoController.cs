using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float Speed;

    [SerializeField] private double Health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Sigue al personaje a la velocidad speed
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, Speed*Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            objetivo.GetComponent<PlayerController>().GetHurt();
        }
    }

    public void TakeDamage(double damage)
    {
        Health = Health-damage;
        Debug.Log(Health);
        if (Health <= 0)
        {
            DropXP();
        }
    }

    void DropXP()
    {
        //Aqui suelta los puntos
        //Destroy(gameObject);
    }
}
