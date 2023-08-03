using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletModel : MonoBehaviour
{
    // �e�̑��x
    private Vector3 _velocity;

    private void Update()
    {
        Application.targetFrameRate = 60;

        // �e�𓮂���
        transform.position += _velocity;
    }

    /// <summary>
    /// �v���C���[�̕����֒e�̑��x��ݒ肷��֐�
    /// </summary>
    /// <param name="speed">�e�̑���</param>
    /// <param name="myPos">���ˈʒu</param>
    /// <param name="plPos">�v���C���[�̈ʒu</param>
    public void FollowingBullet(float speed, Vector3 myPos, Vector3 plPos)
    {
        // ���ˈʒu����v���C���[�֌������P�ʃx�N�g�������߂�
        Vector3 direction = (plPos - myPos).normalized;

        // �e�̑��x�����߂�
        _velocity = direction * speed;
    }
}
