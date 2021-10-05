using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")]
    public Bound movementBound;
    public Bound startingRange;

    [Header("Bullets")]
    public BulletManager bulletManager;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public int frameDelay;

    private float randomSpeed;
    private float startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(movementBound.min, movementBound.max);
        startingPoint = Random.Range(startingRange.min, startingRange.max);

        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startingPoint, transform.position.y);
    }

    private void FixedUpdate()
    {
        if (Time.frameCount % frameDelay == 0)
        {
            //var tempBullet = Instantiate(bulletPrefab);
            //tempBullet.transform.position = bulletSpawn.position;

            bulletManager.GetBullet(bulletSpawn.position);
        }
    }
}
