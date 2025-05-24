using UnityEngine;

public class ScalingController : MonoBehaviour
{
    [SerializeField] private float scalingInterval = 300f;

    private float nextScalingTime = 0f;

    public float Scalinglevel = 1f;

    //Inicio el primer tiempo de escalado
    void Start()
    {
        nextScalingTime = Time.time + scalingInterval;
    }

    // Compruebo si ha pasado el tiempo necesario para aumentar el escalado
    void Update()
    {
        if (Time.time >= nextScalingTime)
        {
            IncrementCounter();
            nextScalingTime = Time.time + scalingInterval;
            Debug.Log(Scalinglevel);
        }
    }

    //En este metodo aumentamos el numero de escalado
    void IncrementCounter()
    {
        Scalinglevel += 1f;

        // Aquí podemos añadir el aviso para otras cosas
    }

    //Reiniciamos todo desde el principio
    public void ResetCounter()
    {
        Scalinglevel = 1f;
        nextScalingTime = Time.time + scalingInterval;
    }
}
