using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // プレイヤーの Rigidbody2D
    [SerializeField]
    private Rigidbody2D _rb = null;

    // プレイヤーの移動速度
    [SerializeField]
    private float _moveSpeed = 0.1f;

    // 左シフトキーが押されているか判定する変数
    public bool LeftShiftPushed;

    // Start is called before the first frame update
    void Start()
    {
        // Null チェック
        if (_rb == null)
        {
            _rb = this.GetComponent<Rigidbody2D>();
        }
    }

    /// <summary>
    /// 縦・横方向の入力に応じてプレイヤーを動かす関数
    /// </summary>
    /// <param name="pos">プレイヤーの位置</param>
    /// <param name="horizontal">横方向の入力</param>
    /// <param name="vertical">縦方向の入力</param>
    /// <returns></returns>
    public Vector3 PlayerMove(Vector3 pos, float horizontal, float vertical)
    {
        // 左シフトキーが押されている場合、移動速度を遅くする
        if (LeftShiftPushed)
        {
            pos.x += horizontal * _moveSpeed / 10;
            pos.y += vertical *_moveSpeed / 10;
        }
        // 押されていない場合
        else
        {
            pos.x += horizontal * _moveSpeed;
            pos.y += vertical * _moveSpeed;
        }

        // プレイヤーの位置を返す
        return pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    } 
}
