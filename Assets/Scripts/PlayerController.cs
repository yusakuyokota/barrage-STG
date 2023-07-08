using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _playerModel = null;

    private Vector2 _pos;

    [SerializeField]
    private PlayerShot _shotPrefab; // �e�̃v���n�u
    [SerializeField]
    private float _shotSpeed; // �e�̈ړ��̑���
    [SerializeField] 
    private float _shotAngleRange; // �����̒e�𔭎˂��鎞�̊p�x
    [SerializeField]
    private float _shotTimer; // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[
    [SerializeField]
    private int _shotCount; // �e�̔��ː�
    [SerializeField] 
    private float _shotInterval; // �e�̔��ˊԊu�i�b�j
        
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        _playerModel = new PlayerModel();
        _pos = transform.position;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _pos = _playerModel.PlayerMove(_pos, horizontal, vertical);
        transform.position = _pos;

        if (Input.GetMouseButtonDown(0))
        {
            ShotNWay(0, 15, 1000, 3);
        }
    }

    private void ShotNWay(float angleBase, float angleRange, float speed, int count)
    {
        var pos = transform.localPosition;
        var rot = transform.localRotation;

        if (1 < count)
        {
            for (int i = 0; i < count; i++)
            {
                var angle = angleBase + angleRange * ((float)i / (count -1) - 0.5f);

                var shot = Instantiate(_shotPrefab, pos, rot);

                shot.Init(angle);
            }
        }
        else if (count == 1)
        {
            // ���˂���e�𐶐�����
            var shot = Instantiate(_shotPrefab, pos, rot);

            // �e�𔭎˂�������Ƒ�����ݒ肷��
            shot.Init(angleBase);
        }
    }
}
