using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory
{
    private static BulletFactory instance = null;

    [Header("Bullet Types")]
    public GameObject enemyBullet;
    public GameObject playerBullet;

    private GameController gameController;

    private BulletFactory()
    {
        Initialize();
    }

    public static BulletFactory Instance()
    {
        if (instance == null)
        {
            instance = new BulletFactory();
        }

        return instance;
    }

    private void Initialize()
    {
        enemyBullet = Resources.Load("Prefabs/EnemyBullet") as GameObject;
        playerBullet = Resources.Load("Prefabs/PlayerBullet") as GameObject;

        gameController = GameObject.FindObjectOfType<GameController>();
    }

    public GameObject createBullet(BulletType type = BulletType.ENEMY)
    {
        GameObject tempBullet = null;

        switch(type)
        {
            case BulletType.ENEMY:
                tempBullet = MonoBehaviour.Instantiate(enemyBullet);
                break;
            case BulletType.PLAYER:
                tempBullet = MonoBehaviour.Instantiate(playerBullet);
                break;
        }

        tempBullet.transform.parent = gameController.gameObject.transform;
        tempBullet.SetActive(false);

        return tempBullet;
    }
}
