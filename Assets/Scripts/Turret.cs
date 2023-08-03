using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // プレイヤーの弾のプレハブ
    [SerializeField]
    private PlayerBulletModel _playerBullet;
    // 弾の速さ
    [SerializeField]
    private float _bulletSpeed;
    // 複数の弾を発射するときの攻撃範囲
    [SerializeField] 
    private float _fireAngleRange;
    // 弾の発射タイミングを管理するタイマー
    [SerializeField]
    private float _shotTimer;
    // 弾の発射数
    [SerializeField]
    private uint _shotCount;
    // 弾の発射間隔
    [SerializeField]
    private float _shotInterval;

    private void Update()
    {
        // タイマーを更新する
        _shotTimer += Time.deltaTime;

        // 発射タイミング出ないときは、ここで処理を終了する
        if (_shotTimer < _shotInterval) return;

        // タイマーをリセットする
        _shotTimer = 0;

        // 弾を発射する
        ShotNWay(_fireAngleRange, _bulletSpeed, _shotCount);
    }

    /// <summary>
    /// 弾を発射する関数
    /// </summary>
    /// <param name="angleRange">攻撃範囲（角度）</param>
    /// <param name="speed">弾の速さ</param>
    /// <param name="count">弾の発射数</param>
    private void ShotNWay(float angleRange, float speed, uint count)
    {
        // 発射位置
        var pos = transform.position;

        // 弾を複数発射する場合
        if (1 < count)
        {
            // 発射する数だけ繰り返す
            for (int i = 0; i < count; i++)
            {
                // 弾の発射角度を求める
                var angle = angleRange * ((float)i / (count - 1) - 0.5f) + 90;

                // 弾を生成する
                var playerBullet = Instantiate(_playerBullet, pos, Quaternion.identity);

                // 弾の発射角度、速さを初期化する
                playerBullet.BulletInit(angle, speed);
            }
        }
        // 弾を一つ発射する場合
        else if (count == 1)
        {
            // 弾を生成する
            var bullet = Instantiate(_playerBullet, pos, Quaternion.identity);

            // 弾の発射角度、速さを初期化する
            bullet.BulletInit(90, speed);
        }
    }
}
