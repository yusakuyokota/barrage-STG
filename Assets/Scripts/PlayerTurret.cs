using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    // �v���C���[�̒e�̃v���n�u
    [SerializeField]
    private BulletModel playerBullet;
    // �e�̑���
    [SerializeField]
    private float bulletSpeed;
    // �����̒e�𔭎˂���Ƃ��̍U���͈�
    [SerializeField] 
    public float fireAngleRange;
    // �e�̔��ː�
    [SerializeField]
    public uint shotCount;
    // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[
    [SerializeField]
    private float shotTimer;
    // �e�̔��ˊԊu
    [SerializeField]
    private float shotInterval;

    private bool canDecreaseAngle = true;
    private bool canIncreaseAngle = true;

    private void Update()
    {
        // �^�C�}�[���X�V����
        shotTimer += Time.deltaTime;

        // ���˃^�C�~���O�łȂ��Ƃ��́A�����ŏ������I������
        if (shotTimer < shotInterval) return;

        // �^�C�}�[�����Z�b�g����
        shotTimer = 0;

        // �e�𔭎˂���
        ShotNWay(fireAngleRange, bulletSpeed, shotCount);
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
                var playerBullet = Instantiate(this.playerBullet, pos, Quaternion.identity);

                playerBullet.tag = "PlayerBullet";

                // �e�̔��ˊp�x�A����������������
                playerBullet.BulletInit(angle, speed);
            }
        }
        // �e������˂���ꍇ
        else if (count == 1)
        {
            // �e�𐶐�����
            var bullet = Instantiate(playerBullet, pos, Quaternion.identity);

            // �e�̔��ˊp�x�A����������������
            bullet.BulletInit(90, speed);
        }
    }

    public void FireAngleChange(float fl)
    {
        if (canIncreaseAngle && canDecreaseAngle)
        {
            fireAngleRange -= fl;
        }

        if (fireAngleRange > 30f)
        {
            fireAngleRange = 30f;
        }
        else if (fireAngleRange < 3f)
        {
            fireAngleRange = 3f;
        }
    }
}
