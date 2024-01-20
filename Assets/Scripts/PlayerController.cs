using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    // プレイヤーモデルのスクリプト
    [SerializeField]
    private PlayerModel playerModel = null;

    // プレイヤービューのスクリプト
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

        // Null チェック
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
    /// プレイヤー移動関数
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
    /// プレイヤーの移動方向を取得
    /// </summary>
    private Vector2 OnMove()
    {
        Vector2 plMoveDirection = inp.Player.Move.ReadValue<Vector2>();
        return plMoveDirection;
    }

    /// <summary>
    /// マウスホイールの回転を取得して正規化する
    /// </summary>
    /// <returns></returns>
    private Vector2 InputMouseWheel()
    {
        Vector2 mouseWheel = inp.Player.MouseWheel.ReadValue<Vector2>().normalized;
        return mouseWheel;
    }
}
