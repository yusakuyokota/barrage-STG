using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField]
    private BulletModel enemyBullet;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private float initialAngle;

    private float bulletAngle;

    [SerializeField]
    private float addAngle;

    [SerializeField]
    private float angleRange;

    private float timeLine;

    [SerializeField]
    private bool antiClockWise;

    private int key;


    private void Start()
    {
        if (antiClockWise) key = -1;
        else key = 1;
        bulletAngle = initialAngle;
    }

    private void Update()
    {
        if (GameManager.Instance.GetPlayerDie() == true) return;

        Application.targetFrameRate = 60;

        timeLine += Time.deltaTime;

        if (timeLine >= 0.2f)
        {
            WaveShot();
            timeLine = 0;
        }
    }

    private void WaveShot()
    {
        var bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);

        bullet.tag = "EnemyBullet";

        bullet.BulletInit(bulletAngle, bulletSpeed);

        bulletAngle += addAngle * key;

        if (antiClockWise)
        {
            if (bulletAngle <= angleRange
            || bulletAngle >= initialAngle) key *= -1;
        }
        else
        {
            if (bulletAngle >= angleRange
            || bulletAngle <= initialAngle) key *= -1;
        }
    }
}
