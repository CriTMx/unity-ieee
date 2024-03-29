using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBulletMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float projectileSpeed = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(projectileSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Bounds"))
        {
            Destroy(this.gameObject);
        }
/*
        if (collision.CompareTag("PickupHealth") || collision.CompareTag("PickupAmmo") || collision.CompareTag("PickupGem"))
        {
            Destroy(this.gameObject);
        }*/
    }
}
