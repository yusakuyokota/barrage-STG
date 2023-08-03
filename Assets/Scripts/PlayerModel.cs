using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // �v���C���[�� Rigidbody2D
    [SerializeField]
    private Rigidbody2D _rb = null;

    // �v���C���[�̈ړ����x
    [SerializeField]
    private float _moveSpeed = 0.1f;

    // ���V�t�g�L�[��������Ă��邩���肷��ϐ�
    public bool LeftShiftPushed;

    // Start is called before the first frame update
    void Start()
    {
        // Null �`�F�b�N
        if (_rb == null)
        {
            _rb = this.GetComponent<Rigidbody2D>();
        }
    }

    /// <summary>
    /// �c�E�������̓��͂ɉ����ăv���C���[�𓮂����֐�
    /// </summary>
    /// <param name="pos">�v���C���[�̈ʒu</param>
    /// <param name="horizontal">�������̓���</param>
    /// <param name="vertical">�c�����̓���</param>
    /// <returns></returns>
    public Vector3 PlayerMove(Vector3 pos, float horizontal, float vertical)
    {
        // ���V�t�g�L�[��������Ă���ꍇ�A�ړ����x��x������
        if (LeftShiftPushed)
        {
            pos.x += horizontal * _moveSpeed / 10;
            pos.y += vertical *_moveSpeed / 10;
        }
        // ������Ă��Ȃ��ꍇ
        else
        {
            pos.x += horizontal * _moveSpeed;
            pos.y += vertical * _moveSpeed;
        }

        // �v���C���[�̈ʒu��Ԃ�
        return pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    } 
}
