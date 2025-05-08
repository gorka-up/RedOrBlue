using UnityEngine;

public class ParticleController : MonoBehaviour
{
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
        particles.Play();
    }

}
