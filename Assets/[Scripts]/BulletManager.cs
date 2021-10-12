using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;
    public int enemyBulletNumber;
    public int playerBulletNumber;

    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        enemyBulletPool = new Queue<GameObject>();
        playerBulletPool = new Queue<GameObject>();

        factory = GetComponent<BulletFactory>();

        // BuildBulletPool();
    }

    public void BuildBulletPool()
    {
        for (int i = 0; i < enemyBulletNumber; i++)
        {
            AddBullet();
        }
    }

    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var tempBullet = factory.createBullet(type);

        switch(type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(tempBullet);
                enemyBulletNumber++;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(tempBullet);
                playerBulletNumber++;
                break;
        }
    }

    public GameObject GetBullet(Vector2 position, BulletType type = BulletType.ENEMY)
    {
        GameObject tempBullet = null;

        switch(type)
        {
            case BulletType.ENEMY:

                if (enemyBulletPool.Count < 1)
                {
                    AddBullet();
                }

                tempBullet = enemyBulletPool.Dequeue();
                tempBullet.transform.position = position;
                tempBullet.SetActive(true);

                break;
            case BulletType.PLAYER:

                if (playerBulletPool.Count < 1)
                {
                    AddBullet(BulletType.PLAYER);
                }

                tempBullet = playerBulletPool.Dequeue();
                tempBullet.transform.position = position;
                tempBullet.SetActive(true);

                break;
        }

        return tempBullet;
    }

    public void ReturnBullet(GameObject bullet, BulletType type = BulletType.ENEMY)
    {
        bullet.SetActive(false);

        switch(type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(bullet);
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(bullet);
                break;
        }
    }
}
