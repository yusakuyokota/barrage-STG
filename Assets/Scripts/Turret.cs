using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // �v���C���[�̒e�̃v���n�u
    [SerializeField]
    private PlayerBulletModel _playerBullet;
    // �e�̑���
    [SerializeField]
    private float _bulletSpeed;
    // �����̒e�𔭎˂���Ƃ��̍U���͈�
    [SerializeField] 
    private float _fireAngleRange;
    // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[
    [SerializeField]
    private float _shotTimer;
    // �e�̔��ː�
    [SerializeField]
    private uint _shotCount;
    // �e�̔��ˊԊu
    [SerializeField]
    private float _shotInterval;

    private void Update()
    {
        // �^�C�}�[���X�V����
        _shotTimer += Time.deltaTime;

        // ���˃^�C�~���O�o�Ȃ��Ƃ��́A�����ŏ������I������
        if (_shotTimer < _shotInterval) return;

        // �^�C�}�[�����Z�b�g����
        _shotTimer = 0;

        // �e�𔭎˂���
        ShotNWay(_fireAngleRange, _bulletSpeed, _shotCount);
    }

    /// <summary>
    /// �e�𔭎˂���֐�
    /// </summary>
    /// <param name="angleRange">�U���͈́i�p�x�j</param>
    /// <param name="speed">�e�̑���</param>
    /// <param name="count">�e�̔��ː�</param>
    private void ShotNWay(float angleRange, float speed, uint count)
    {
        // ���ˈʒu
        var pos = transform.position;

        // �e�𕡐����˂���ꍇ
        if (1 < count)
        {
            // ���˂��鐔�����J��Ԃ�
            for (int i = 0; i < count; i++)
            {
                // �e�̔��ˊp�x�����߂�
                var angle = angleRange * ((float)i / (count - 1) - 0.5f) + 90;

                // �e�𐶐�����
                var playerBullet = Instantiate(_playerBullet, pos, Quaternion.identity);

                // �e�̔��ˊp�x�A����������������
                playerBullet.BulletInit(angle, speed);
            }
        }
        // �e������˂���ꍇ
        else if (count == 1)
        {
            // �e�𐶐�����
            var bullet = Instantiate(_playerBullet, pos, Quaternion.identity);

            // �e�̔��ˊp�x�A����������������
            bullet.BulletInit(90, speed);
        }
    }
}
