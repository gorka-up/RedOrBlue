using UnityEngine;

public class HitController : MonoBehaviour
{
    BasicEnemyController basicEnemyController;

    void Start()
    {
        //Pillo el controller de padre para poder utilizar el collider2D del hijo como triger
        basicEnemyController = transform.parent.GetComponent<BasicEnemyController>();
    }

    //Le paso con lo que esta colisionando y si es el player le hago daño
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject == basicEnemyController.enemigoController.targetGameObject)
        {
            basicEnemyController.Attack();
        }
    }
}
