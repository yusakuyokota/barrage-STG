using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletModel : MonoBehaviour
{
    // 弾の速度
    private Vector3 _velocity;

    private Vector3 _baseVelocity = new Vector3(0, -1, 0);

    [SerializeField, Header("RandomShotの角度の始点")]
    private float _angleStartPoint;

    [SerializeField, Header("RandomShotの角度の終点")]
    private float _angleEndPoint;

    private void Update()
    {
        Application.targetFrameRate = 60;

        // 弾を動かす
        transform.position += _velocity;
    }

    /// <summary>
    /// プレイヤーの方向へ弾の速度を設定する関数
    /// </summary>
    /// <param name="speed">弾の速さ</param>
    /// <param name="myPos">発射位置</param>
    /// <param name="plPos">プレイヤーの位置</param>
    public void FollowingBullet(float speed, Vector3 myPos, Vector3 plPos)
    {
        // 発射位置からプレイヤーへ向かう単位ベクトルを求める
        Vector3 direction = (plPos - myPos).normalized;

        // 弾の速度を求める
        _velocity = direction * speed;
    }

    public void RandomShot(float speed)
    {
        Vector3 direction = Utils.GetDirection(Random.Range(_angleStartPoint, _angleEndPoint));

        _velocity = direction.normalized * speed;
    }
}
