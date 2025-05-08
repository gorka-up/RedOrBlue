using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public EnemigoController enemigoController;
    private ParticleSystem particles;
    float deltatime;
    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        RotationForParticles();
    }
    private void Update()
    {
        deltatime += Time.deltaTime;
        if(deltatime > 1)
        {
            Destroy(gameObject);
        }
    }
    void RotationForParticles()
    {
        //float angle = Vector3.Angle(Vector3.one, enemigoController.transform.position - enemigoController.objetivo.transform.position);
        //transform.Rotate(0f,0f,angle);
        particles.Play();
    }

}
