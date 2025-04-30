using UnityEngine;

public class BLue_BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Wall":
                {
                    Destroy(gameObject);
                    break;
                }
            case "Blue_Enemy":
                {
                    //other.GameObject.GetComponent<EnemigoController>().TakeDamage(damage);
                    Destroy(gameObject);
                    break;
                }
            case "Red_Enemy":
                {
                    Destroy(gameObject);
                    break;
                }
        }
    }
}
