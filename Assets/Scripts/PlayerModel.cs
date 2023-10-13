using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // プレイヤーの Rigidbody2D
    [SerializeField]
    private Rigidbody2D _rb = null;

    // プレイヤーの移動速度
    private float _moveSpeed = 0.05f;

    private bool _invincible = false;

    public int _playerLife;

    private Collider2D _collider2D = null;

    // Start is called before the first frame update
    void Start()
    {
        // Null チェック
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        if (_collider2D == null)
        {
            _collider2D = GetComponent<Collider2D>();
        }

        _playerLife = GameManager.Instance.life;

        if (_playerLife != 10)
        {
            _collider2D.isTrigger = false;
        }
    }

    public Vector3 PlayerMove2(Vector3 pos, int keyX, int keyY)
    {
        float speedY = Mathf.Abs(_rb.velocity.y);
        float speedX = Mathf.Abs(_rb.velocity.x);

        Vector3 velocity = Vector3.zero;

        if (speedY < _moveSpeed)
        {
            velocity += Vector3.up * keyY;
        }
        if (speedX < _moveSpeed)
        {
            velocity += Vector3.right * keyX;
        }

        velocity = velocity.normalized * _moveSpeed;

        Debug.Log(velocity);

        pos += velocity;

        return pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 敵の攻撃を食らったとき
        if (collision.gameObject.tag == "EnemyShot")
        {
            if (!_invincible)
            {
                Destroy(collision.gameObject);
                GameManager.Instance.IsPlayerDie = true;
            }
        }
    }
}
