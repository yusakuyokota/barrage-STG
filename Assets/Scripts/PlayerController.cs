using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �v���C���[���f���̃X�N���v�g
    [SerializeField]
    private PlayerModel _playerModel = null;

    // �v���C���[�r���[�̃X�N���v�g
    [SerializeField]
    private PlayerView _playerView = null;

    private void Start()
    {
        // Null �`�F�b�N
        if (_playerModel == null)
        {
            _playerModel = GetComponent<PlayerModel>();
        }

        // Null �`�F�b�N
        if (_playerView == null)
        {
            _playerView = GetComponent<PlayerView>();
        }
    }

    private void Update()
    {
        Application.targetFrameRate = 60;

        // �v���C���[�̈ړ����͂��󂯎��
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �v���C���[�𓮂���
        _playerView._pos = _playerModel.PlayerMove(_playerView._pos, horizontal, vertical);
    }
}
