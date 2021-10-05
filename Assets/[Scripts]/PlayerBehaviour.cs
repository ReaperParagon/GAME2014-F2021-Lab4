using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0.0f, 100.0f)]
    public float horizontalForce;

    [SerializeField]
    private Bound bounds;

    [Range(0.0f, 0.99f)]
    public float decay = 0.95f;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        rigidbody.AddForce(new Vector2(x * horizontalForce, 0.0f));

        rigidbody.velocity *= (1.0f - decay);
    }

    private void CheckBounds()
    {

        // Left Bounds
        if(transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }

        // Right Bounds
        if(transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
