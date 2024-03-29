using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 15f;

    [SerializeField]
    private float maxMoveSpeed = 45f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Random.Range(-moveSpeed, -maxMoveSpeed), 0f);

        if (this.CompareTag("PickupHealth") || this.CompareTag("PickupAmmo") || this.CompareTag("PickupGem"))
        {
            transform.Rotate(180f * Time.deltaTime * Vector3.forward);
        }
    }
}
