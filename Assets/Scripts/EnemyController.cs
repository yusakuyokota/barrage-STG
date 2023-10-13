using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyBulletModel _enemyBullet;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _shotTimer;
    [SerializeField]
    private float _shotInterval;

    private void Start()
    {

    }

    private void Update()
    {
        if (GameManager.Instance.IsPlayerDie == true) return;

        _shotTimer += Time.deltaTime;

        if (_shotTimer < _shotInterval) return;

        _shotTimer = 0;

        ShotBullet(_bulletSpeed);
    }

    private void ShotBullet(float speed)
    {
        

        Vector3 pos = transform.position;

        var enemyBullet = Instantiate(_enemyBullet, pos, Quaternion.identity);

        //enemyBullet.FollowingBullet(speed, pos, plPos);

        enemyBullet.RandomShot(speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShot")
        {
            //Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
