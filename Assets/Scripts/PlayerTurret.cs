using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    // プレイヤーの弾のプレハブ
    [SerializeField]
    private BulletModel playerBullet;
    // 弾の速さ
    [SerializeField]
    private float bulletSpeed;
    // 複数の弾を発射するときの攻撃範囲
    [SerializeField] 
    public float fireAngleRange;
    // 弾の発射数
    [SerializeField]
    public uint shotCount;
    // 弾の発射タイミングを管理するタイマー
    [SerializeField]
    private float shotTimer;
    // 弾の発射間隔
    [SerializeField]
    private float shotInterval;

    private bool canDecreaseAngle = true;
    private bool canIncreaseAngle = true;

    private void Update()
    {
        // タイマーを更新する
        shotTimer += Time.deltaTime;

        // 発射タイミングでないときは、ここで処理を終了する
        if (shotTimer < shotInterval) return;

        // タイマーをリセットする
        shotTimer = 0;

        // 弾を発射する
        ShotNWay(fireAngleRange, bulletSpeed, shotCount);
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
                var playerBullet = Instantiate(this.playerBullet, pos, Quaternion.identity);

                playerBullet.tag = "PlayerBullet";

                // 弾の発射角度、速さを初期化する
                playerBullet.BulletInit(angle, speed);
            }
        }
        // 弾を一つ発射する場合
        else if (count == 1)
        {
            // 弾を生成する
            var bullet = Instantiate(playerBullet, pos, Quaternion.identity);

            // 弾の発射角度、速さを初期化する
            bullet.BulletInit(90, speed);
        }
    }

    public void FireAngleChange(float fl)
    {
        if (canIncreaseAngle && canDecreaseAngle)
        {
            fireAngleRange -= fl;
        }

        if (fireAngleRange > 30f)
        {
            fireAngleRange = 30f;
        }
        else if (fireAngleRange < 3f)
        {
            fireAngleRange = 3f;
        }
    }
}
