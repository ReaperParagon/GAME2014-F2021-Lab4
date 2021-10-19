using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public BulletType type;

    [Header("Bullet Movement")]
    public Vector3 bulletVelocity;
    public Bound bulletBounds;

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
            BulletManager.Instance().ReturnBullet(gameObject, type);
        }

        // Checks Top Bounds
        if (transform.position.y > bulletBounds.min)
        {
            BulletManager.Instance().ReturnBullet(gameObject, type);
        }
    }
}
