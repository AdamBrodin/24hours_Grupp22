using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBomberrDude : MonoBehaviour
{
    public float enemyspeed;
    public float bulletspeed;
    public float firerate;
    public GameObject bullet;
    public float nexshoot;
    Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        nexshoot -= Time.deltaTime;
        transform.Translate(enemyspeed * Time.deltaTime, 0, 0);
        //Räknar ut en random riktning

        if (nexshoot <= 0)
        {
            nexshoot = 1 / firerate;
            //Skjuter bullets i en random direction med delay
            GameObject randombullet = Instantiate(bullet, transform.position, Quaternion.identity);
            randombullet.GetComponent<Rigidbody2D>().velocity = transform.up * -bulletspeed;
            Destroy(randombullet, 2f);  

        }
    }
}
