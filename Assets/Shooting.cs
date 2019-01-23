using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Gun gun;
    public GameObject Bullet;
    [Space]
    public Transform firepoint;
    [Space]
    public float nexshoot;

    private void FixedUpdate()
    {
        nexshoot -= Time.deltaTime;
        FaceMouse();
        shooting();
    }

    void FaceMouse()
    {

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 3);
    }

    void shooting()
    {
        if (Input.GetButton("Fire1") && nexshoot <= 0)
        {

            CamerShake camra = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamerShake>();
            camra.DoCameraShake(gun.shakeduration);
            nexshoot = 1 / gun.firerate;
            GameObject projectile = Instantiate(Bullet, firepoint.position, transform.rotation) as GameObject;
            Bullet bulscrip = projectile.GetComponent<Bullet>();
            bulscrip.setrotation(gun.spread);
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * gun.bulletspeed;
            Destroy(projectile, gun.lifetime);

            transform.position -= transform.up   * gun.knockback;
        }
    }

}
