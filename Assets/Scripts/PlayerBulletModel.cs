using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletModel : MonoBehaviour
{
    // �e�̑��x
    private Vector3 _velocity;

    private void Update()
    {
        Application.targetFrameRate = 60;

        // �e�𓮂���
        transform.position += _velocity;
        
        // ��ʊO�ɏo���Ƃ��ɃI�u�W�F�N�g����������
        if (transform.position.x > 11 ||
            transform.position.x < -11 ||
            transform.position.y > 6 ||
            transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �e�̔��ˊp�x�A����������������֐�
    /// </summary>
    /// <param name="angle">�e�̔��ˊp�x</param>
    /// <param name="speed">�e�̑���</param>
    public void BulletInit(float angle, float speed)
    {
        // ���ˊp�x����x�N�g�����擾����
        Vector3 direction = GetDirection(angle);

        // ���x�����߂�
        _velocity = direction * speed;

        // �e��i�s�����Ɍ�����
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;
    }

    /// <summary>
    /// �^����ꂽ�p�x����x�N�g����Ԃ��֐�
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
