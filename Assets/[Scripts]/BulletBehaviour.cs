using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Movement")]
    [Range(0.0f, 2.0f)]
    public float speed;
    public Bound bulletBounds;
    public BulletDirection direction;

    private BulletManager bulletManager;
    private Vector3 bulletVelocity;

    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        switch(direction)
        {
            case BulletDirection.UP:
                bulletVelocity = new Vector3(0.0f, speed, 0.0f);
                break;
            case BulletDirection.RIGHT:
                bulletVelocity = new Vector3(speed, 0.0f, 0.0f);
                break;
            case BulletDirection.DOWN:
                bulletVelocity = new Vector3(0.0f, -speed, 0.0f);
                break;
            case BulletDirection.LEFT:
                bulletVelocity = new Vector3(-speed, 0.0f, 0.0f);
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += bulletVelocity;
    }

    public void CheckBounds()
    {
        // Checks Bottom Bounds
        if (transform.position.y < bulletBounds.max)
        {
            bulletManager.ReturnBullet(gameObject);
        }

        // Checks Top Bounds
        if (transform.position.y > bulletBounds.min)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}
