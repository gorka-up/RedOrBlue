using UnityEngine;

public class DeleteAudioController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource sound = transform.GetComponent<AudioSource>();
        sound.Play();
        Destroy(gameObject, sound.clip.length);
    }
}
