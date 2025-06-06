using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{    
    Rigidbody rb;

    public EnemigoController enemigoController;

    [SerializeField] GameObject player;
    PlayerController playerController;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemigoController = GetComponent<EnemigoController>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        //Sigue al personaje a la velocidad speed
        transform.position = Vector2.MoveTowards(transform.position, enemigoController.objetivo.position, enemigoController.Speed * Time.deltaTime);
    }

    public void Attack()
    {
        playerController.GetHurt();
    }
}
