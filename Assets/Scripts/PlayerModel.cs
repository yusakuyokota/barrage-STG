using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb = null;

    public float MoveSpeed = 10;

    public bool ShiftPushed;

    // Start is called before the first frame update
    void Start()
    {
        if (_rb == null)
        {
            _rb = this.GetComponent<Rigidbody2D>();
        }
    }

    public Vector2 PlayerMove(Vector2 pos, float horizontal, float vertical)
    {
        if (ShiftPushed)
        {
            pos.x += horizontal * MoveSpeed / 10;
            pos.y += vertical * MoveSpeed / 10;
        }
        else
        {
            pos.x += horizontal * MoveSpeed;
            pos.y += vertical * MoveSpeed;
        }

        return pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("aaa");
    }
}
