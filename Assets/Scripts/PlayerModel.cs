using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // �v���C���[�� Rigidbody2D
    [SerializeField]
    private Rigidbody2D rb = null;

    // �v���C���[�̈ړ����x
    private float moveSpeed = 0.1f;

    private bool invincible = false;

    public int playerLife;

    // Start is called before the first frame update
    void Start()
    {
        // Null �`�F�b�N
        rb ??= GetComponent<Rigidbody2D>();

        playerLife = GameManager.Instance.Life;
    }

    public Vector3 PlayerMove(Vector2 pos, Vector2 velocity, bool shift)
    {
        if (shift) pos += velocity *moveSpeed / 2;
        else pos += velocity * moveSpeed;

        return pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �G�̍U����H������Ƃ�
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if (!invincible)
            {
                Destroy(collision.gameObject);
                GameManager.Instance.SetPlayerDie();
            }
        }
    }
}
