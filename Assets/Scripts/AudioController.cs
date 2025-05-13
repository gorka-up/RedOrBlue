using UnityEngine;

public class AudioController : MonoBehaviour
{
    private float maxPitch = 1.15f;
    private float minPitch = 0.85f;
    void Start()
    {
        AudioSource sound = transform.GetComponent<AudioSource>();
        sound.pitch = Random.Range(minPitch, maxPitch);

        sound.Play();
        Destroy(gameObject, sound.clip.length);
    }
}
