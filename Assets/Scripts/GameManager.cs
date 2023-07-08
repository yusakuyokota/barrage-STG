using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _objPlayer = null;

    public bool IsPlayerDie = false;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        var obj = Resources.Load<GameObject>("Player");
        _objPlayer = Instantiate(obj, new Vector2(0.0f, 0.0f), Quaternion.identity);
    }
}
