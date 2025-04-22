using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject Red_Bullet;
    [SerializeField] private GameObject Blue_Bullet;

    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireForce;

    public bool mode = false;
    public void Fire()
    {
        GameObject projectile;
        if (mode)
        {
            projectile = Instantiate(Blue_Bullet, firePoint.position, firePoint.rotation);
        }
        else
        {
            projectile = Instantiate(Red_Bullet, firePoint.position, firePoint.rotation);
        }
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

 
    public void ChangeMode()
    {
        if (mode)
        {
            mode = false;
        }
        else
        {
            mode = true;
        }
    }
}
