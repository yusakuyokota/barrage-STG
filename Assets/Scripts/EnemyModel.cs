using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [SerializeField]
    private float moveValue;

    private int key = 1;

    [SerializeField,Header("“G‚ÌHP")]
    private uint hp = 300;

    private void Update()
    {
        if (key > 0) transform.position += Vector3.right * Time.deltaTime;

        if (key < 0) transform.position += Vector3.left * Time.deltaTime;

        if (transform.position.x < Utils.XAxisMiddle - moveValue || 
            transform.position.x > Utils.XAxisMiddle + moveValue) 
            key *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);

            hp--;
            GameManager.Instance.ScoreUpdate(100);

            if (hp == 0)
            {
                GameManager.Instance.SetEnemyDie();
            }
        }
    }
}
