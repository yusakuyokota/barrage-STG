using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel : MonoBehaviour
{
    // 弾の速度
    private Vector3 velocity;

    private readonly float speedAdjust = 0.01f;

    private void Update()
    {
        Application.targetFrameRate = 60;

        // 弾を動かす
        transform.position += velocity;
        
        // 画面外に出たときにオブジェクトを消去する
        if (transform.position.x > 2 ||
            transform.position.x < -10 ||
            transform.position.y > 6 ||
            transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 弾の発射角度、速さを初期化する関数
    /// </summary>
    /// <param name="angle">弾の発射角度</param>
    /// <param name="speed">弾の速さ</param>
    public void BulletInit(float angle, float speed)
    {
        // 発射角度からベクトルを取得する
        Vector3 direction = Utils.GetDirection(angle);

        // 速度を求める
        velocity = direction * speed * speedAdjust;

        // 弾を進行方向に向ける
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;
    }
}
