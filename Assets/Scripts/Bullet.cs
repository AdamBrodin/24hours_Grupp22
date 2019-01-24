using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public void setrotation(float spread)
    {
        transform.Rotate(0, 0, Random.Range(-spread, spread));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Health hpscript = collision.gameObject.GetComponent<Health>();
            hpscript.TakeDamage(damage);
            Destroy(gameObject);

            
        }
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
