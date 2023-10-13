using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletModel : MonoBehaviour
{
    // �e�̑��x
    private Vector3 _velocity;

    private Vector3 _baseVelocity = new Vector3(0, -1, 0);

    [SerializeField, Header("RandomShot�̊p�x�̎n�_")]
    private float _angleStartPoint;

    [SerializeField, Header("RandomShot�̊p�x�̏I�_")]
    private float _angleEndPoint;

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

    public void RandomShot(float speed)
    {
        Vector3 direction = Utils.GetDirection(Random.Range(_angleStartPoint, _angleEndPoint));

        _velocity = direction.normalized * speed;
    }
}
