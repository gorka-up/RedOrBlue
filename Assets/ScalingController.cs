using UnityEngine;

public class ScalingController : MonoBehaviour
{
    [SerializeField] private float scalingInterval;

    private float nextScalingTime = 150f;

    public float Scalinglevel = 1f;

    private SpawningController spawningController;

    //Inicio el primer tiempo de escalado
    void Start()
    {
        nextScalingTime = scalingInterval;
        spawningController = GetComponent<SpawningController>();
    }

    // Compruebo si ha pasado el tiempo necesario para aumentar el escalado
    private void FixedUpdate()
    {
        nextScalingTime -= Time.deltaTime;
        if (nextScalingTime < 0f)
        {
            IncrementCounter();
            nextScalingTime = scalingInterval;
            spawningController.SpawnBoss();
            Debug.Log("Entro");
        }
        Debug.Log(nextScalingTime);
    }

    //En este metodo aumentamos el numero de escalado
    void IncrementCounter()
    {
        Scalinglevel += 1f;
        spawningController.ScalingSpawnTime();
        // Aquí podemos añadir el aviso para otras cosas
    }

    //Reiniciamos todo desde el principio
    public void ResetCounter()
    {
        Scalinglevel = 1f;
        nextScalingTime = Time.time + scalingInterval;
    }
}
