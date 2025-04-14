using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float Speed;

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
}
