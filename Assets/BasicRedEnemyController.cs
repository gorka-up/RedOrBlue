using UnityEngine;

public class BasicRedEnemyController : MonoBehaviour
{
    [SerializeField] Transform objetivo;
    GameObject targetGameObject;
    

    Rigidbody rb;

    [SerializeField] public double Health = 10;
    [SerializeField] public float Speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        objetivo = target.transform;
    }

    void FixedUpdate()
    {
        //Sigue al personaje a la velocidad speed
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, Speed * Time.deltaTime);
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
}
