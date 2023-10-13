using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    // �v���C���[���f���̃X�N���v�g
    [SerializeField]
    private PlayerModel _playerModel = null;

    // �v���C���[�r���[�̃X�N���v�g
    [SerializeField]
    private PlayerView _playerView = null;

    private readonly float _playerMoveSpeed = 0.5f;

    private float _playerHorizontalMoveSpeed = 0f;

    private float _playerVerticalMoveSpeed = 0f;

    private bool _leftShiftKeyDowned = false;

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

        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
        {
            Debug.LogError("�L�[�{�[�h���ڑ�����Ă��܂���");
            UnityEditor.EditorApplication.isPaused = true;
        }

        KeyControl wKey = keyboard.wKey;
        KeyControl aKey = keyboard.aKey;
        KeyControl sKey = keyboard.sKey;
        KeyControl dKey = keyboard.dKey;

        int keyX = 0;
        int keyY = 0;

        if (wKey.isPressed) keyY = 1;
        if (sKey.isPressed) keyY = -1;
        if (dKey.isPressed) keyX = 1;
        if (aKey.isPressed) keyX = -1;

        if (Input.GetKey(KeyCode.LeftShift)) _leftShiftKeyDowned = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) _leftShiftKeyDowned = false;

        _playerView._pos = _playerModel.PlayerMove2(_playerView._pos
                                                  , keyX
                                                  , keyY );
    }
}
