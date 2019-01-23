using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void setrotation(float spread)
    {
        transform.Rotate(0, 0, Random.Range(-spread, spread));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
        }
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
