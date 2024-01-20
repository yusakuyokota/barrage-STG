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
    private PlayerModel playerModel = null;

    // �v���C���[�r���[�̃X�N���v�g
    [SerializeField]
    private PlayerView playerView = null;

    [SerializeField]
    private PlayerTurret turret;

    private ControllerInput inp;

    private Vector2 moveInputValue;

    private bool leftShiftKeyDowned = false;

    private void Start()
    {
        Application.targetFrameRate = 60;

        inp = ControllerManager.instance.CtrlInput;

        inp.Enable();

        // Null �`�F�b�N
        playerModel ??= GetComponent<PlayerModel>();
        playerView ??= GetComponent<PlayerView>();
    }

    private void Update()
    {
        PlayerMove();

        if (inp.Player.MouseWheel.ReadValue<Vector2>() != Vector2.zero)
            turret.FireAngleChange(InputMouseWheel().y);
    }

    /// <summary>
    /// �v���C���[�ړ��֐�
    /// </summary>
    private void PlayerMove()
    {
        if (inp.Player.Shift.IsPressed()) leftShiftKeyDowned = true;
        if (inp.Player.Shift.WasReleasedThisFrame()) leftShiftKeyDowned = false;

        if (inp.Player.Move.IsPressed()) moveInputValue = OnMove();
        if (inp.Player.Move.WasReleasedThisFrame()) moveInputValue = OnMove();

        playerView.pos =
            playerModel.PlayerMove(playerView.pos, moveInputValue, leftShiftKeyDowned);
    }

    /// <summary>
    /// �v���C���[�̈ړ��������擾
    /// </summary>
    private Vector2 OnMove()
    {
        Vector2 plMoveDirection = inp.Player.Move.ReadValue<Vector2>();
        return plMoveDirection;
    }

    /// <summary>
    /// �}�E�X�z�C�[���̉�]���擾���Đ��K������
    /// </summary>
    /// <returns></returns>
    private Vector2 InputMouseWheel()
    {
        Vector2 mouseWheel = inp.Player.MouseWheel.ReadValue<Vector2>().normalized;
        return mouseWheel;
    }
}
