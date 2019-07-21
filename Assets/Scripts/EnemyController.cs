using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public int armour;
    public GameObject explosion;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = -transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object " + other.tag + " is collided with Enemy");
        if (other.CompareTag("PlayerBullet"))
        {
            armour--;
            if (armour <= 0)
            {
                Destroy(gameObject);
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }
            }
            Destroy(other.gameObject);
        }
    }
}
