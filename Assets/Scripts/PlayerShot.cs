using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    private Vector2 _direction = new Vector2();

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Init(75);
        _rb.AddForce(_direction * 1000, ForceMode2D.Impulse);
    }

    public void Init(float angle)
    {
        _direction = GetDirection(angle);

        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;
    }

    public static Vector2 GetDirection(float angle)
    {
        return new Vector2
        (
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad)
        );
    }
}
