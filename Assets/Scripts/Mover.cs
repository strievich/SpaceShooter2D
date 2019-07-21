using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
    }

}
