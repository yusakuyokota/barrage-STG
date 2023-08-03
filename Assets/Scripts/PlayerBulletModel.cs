using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletModel : MonoBehaviour
{
    // 弾の速度
    private Vector3 _velocity;

    private void Update()
    {
        Application.targetFrameRate = 60;

        // 弾を動かす
        transform.position += _velocity;
        
        // 画面外に出たときにオブジェクトを消去する
        if (transform.position.x > 11 ||
            transform.position.x < -11 ||
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
        Vector3 direction = GetDirection(angle);

        // 速度を求める
        _velocity = direction * speed;

        // 弾を進行方向に向ける
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;
    }

    /// <summary>
    /// 与えられた角度からベクトルを返す関数
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    private Vector3 GetDirection(float angle)
    {
        return new Vector3
            (
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad),
                0
            );
    }
}
