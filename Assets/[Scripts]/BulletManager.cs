using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager
{
    private static BulletManager instance = null;

    private BulletManager()
    {
        Initialize();
    }

    public static BulletManager Instance()
    {
        if (instance == null)
        {
            instance = new BulletManager();
        }

        return instance;
    }

    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;
    public int enemyBulletNumber;
    public int playerBulletNumber;

    public List<Queue<GameObject>> bulletPools;

    private void Initialize()
    {
        bulletPools = new List<Queue<GameObject>>();

        for (int count = 0; count < (int)BulletType.NUMBER_OF_BULLET_TYPES; count++)
        {
            bulletPools.Add(new Queue<GameObject>());
        }
    }

    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var tempBullet = BulletFactory.Instance().createBullet(type);
        bulletPools[(int)type].Enqueue(tempBullet);
    }

    public GameObject GetBullet(Vector2 position, BulletType type = BulletType.ENEMY)
    {
        GameObject tempBullet = null;

        if (bulletPools[(int)type].Count < 1)
        {
            AddBullet(type);
        }

        tempBullet = bulletPools[(int)type].Dequeue();
        tempBullet.transform.position = position;
        tempBullet.SetActive(true);

        return tempBullet;
    }

    public void ReturnBullet(GameObject bullet, BulletType type = BulletType.ENEMY)
    {
        bullet.SetActive(false);
        bulletPools[(int)type].Enqueue(bullet);
    }
}
