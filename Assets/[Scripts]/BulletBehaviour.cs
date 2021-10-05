using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Range(0.0f, 2.0f)]
    public float speed;
    public BulletManager bulletManager;
    public Bound bulletBounds;

    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(0, speed, 0);
        CheckBounds();
    }

    public void CheckBounds()
    {
        if (transform.position.y < bulletBounds.max)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}
