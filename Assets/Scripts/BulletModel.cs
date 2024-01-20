using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel : MonoBehaviour
{
    // �e�̑��x
    private Vector3 velocity;

    private readonly float speedAdjust = 0.01f;

    private void Update()
    {
        Application.targetFrameRate = 60;

        // �e�𓮂���
        transform.position += velocity;
        
        // ��ʊO�ɏo���Ƃ��ɃI�u�W�F�N�g����������
        if (transform.position.x > 2 ||
            transform.position.x < -10 ||
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
        Vector3 direction = Utils.GetDirection(angle);

        // ���x�����߂�
        velocity = direction * speed * speedAdjust;

        // �e��i�s�����Ɍ�����
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;
    }
}
