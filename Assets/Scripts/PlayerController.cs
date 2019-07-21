using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bounds
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour
{
    public delegate void PlayerDead();
    public static event PlayerDead OnPlayerDead;

    private bool isDestroyed = false;

    private Rigidbody2D rb2d;
    public float moveSpeed = 1;
    public Bounds boundary;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireRate;
    private float nextFireTime;
    public GameObject playerExplosion;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        if (!isDestroyed)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            rb2d.velocity = movement * moveSpeed;

            rb2d.position = new Vector2
            (
                Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax)
            );
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bounding") || other.CompareTag("PlayerBullet"))
        {
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            if (playerExplosion != null)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            }
            Destroy(gameObject);
            OnPlayerDead();
        }
        
    }
}
