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
    private PlayerShot _shotPrefab; // 弾のプレハブ
    [SerializeField]
    private float _shotSpeed; // 弾の移動の速さ
    [SerializeField] 
    private float _shotAngleRange; // 複数の弾を発射する時の角度
    [SerializeField]
    private float _shotTimer; // 弾の発射タイミングを管理するタイマー
    [SerializeField]
    private int _shotCount; // 弾の発射数
    [SerializeField] 
    private float _shotInterval; // 弾の発射間隔（秒）
        
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
            // 発射する弾を生成する
            var shot = Instantiate(_shotPrefab, pos, rot);

            // 弾を発射する方向と速さを設定する
            shot.Init(angleBase);
        }
    }
}
