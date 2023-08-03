using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // プレイヤーモデルのスクリプト
    [SerializeField]
    private PlayerModel _playerModel = null;

    // プレイヤービューのスクリプト
    [SerializeField]
    private PlayerView _playerView = null;

    private void Start()
    {
        // Null チェック
        if (_playerModel == null)
        {
            _playerModel = GetComponent<PlayerModel>();
        }

        // Null チェック
        if (_playerView == null)
        {
            _playerView = GetComponent<PlayerView>();
        }
    }

    private void Update()
    {
        Application.targetFrameRate = 60;

        // プレイヤーの移動入力を受け取る
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // プレイヤーを動かす
        _playerView._pos = _playerModel.PlayerMove(_playerView._pos, horizontal, vertical);
    }
}
