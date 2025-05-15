using NUnit.Framework.Constraints;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject Red_Bullet;
    [SerializeField] private GameObject Blue_Bullet;

    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireForce;

    public bool mode = false;

    private float maxPitch = 1.25f;
    private float minPitch = 1.05f;
    AudioSource sound;

    public Sprite redSprite;
    public Sprite blueSprite;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        sound = transform.GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Fire()
    {
        if (Time.timeScale != 0)
        {
            GameObject projectile;
            if (mode)
            {
                sound.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
                sound.Play();

                projectile = Instantiate(Blue_Bullet, firePoint.position, firePoint.rotation);
            }
            else
            {
                sound.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
                sound.Play();
                
                projectile = Instantiate(Red_Bullet, firePoint.position, firePoint.rotation);
            }
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        }
    }

 
    public void ChangeMode()
    {
        if (mode)
        {
            mode = false;
            spriteRenderer.sprite = redSprite;
        }
        else
        {
            mode = true;
            spriteRenderer.sprite = blueSprite;
        }
    }
}
