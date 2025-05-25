using UnityEngine;

public class ScalingController : MonoBehaviour
{
    [SerializeField] private float scalingInterval = 300f;

    private float nextScalingTime = 0f;

    public float Scalinglevel = 1f;

    private SpawningController spawningController;

    //Inicio el primer tiempo de escalado
    void Start()
    {
        nextScalingTime = Time.time + scalingInterval;
        spawningController = GetComponent<SpawningController>();
    }

    // Compruebo si ha pasado el tiempo necesario para aumentar el escalado
    void Update()
    {
        if (Time.time >= nextScalingTime)
        {
            IncrementCounter();
            nextScalingTime = Time.time + scalingInterval;
            spawningController.SpawnBoss();
        }
    }

    //En este metodo aumentamos el numero de escalado
    void IncrementCounter()
    {
        Scalinglevel += 1f;

        // Aqu� podemos a�adir el aviso para otras cosas
    }

    //Reiniciamos todo desde el principio
    public void ResetCounter()
    {
        Scalinglevel = 1f;
        nextScalingTime = Time.time + scalingInterval;
    }
}
