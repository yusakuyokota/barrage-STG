using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static object _lock = new object();

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance
                        = FindObjectOfType<GameManager>();
                    if (_instance == null ) 
                    {
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<GameManager>();
                        singletonObject.name = nameof(GameManager) + "(singleton)";
                    }
                }

                return _instance;
            }
        }
    }

    [SerializeField]
    private GameObject _objPlayer = null;

    [SerializeField]
    private GameObject _objEnemy = null;

    private Vector3 _playerSpawnPos = new Vector3(0, -4, 0);

    public bool IsPlayerDie = false;

    public int life = 10;

    private uint _stageNum = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            // 一応 Warning で知らせる
            Debug.LogWarning("インスタンスがかぶっている");
            Destroy(this);
            return;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        SpawnPlayer();
        SpawnEnemy();
    }

    private void Update()
    {
        if (IsPlayerDie)
        {
            Destroy(_objPlayer);

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyShot");
            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet);
            }

            StartCoroutine(DeraySpawnTime());

            IsPlayerDie = false;
        }
    }

    private void SpawnPlayer()
    {
        IsPlayerDie = false;
        var obj = Resources.Load<GameObject>("Player");
        _objPlayer = Instantiate(obj, _playerSpawnPos, Quaternion.identity);
    }

    private void SpawnEnemy()
    {
        var obj = Resources.Load<GameObject>("Enemy");
        _objEnemy = Instantiate(obj, new Vector3(0, 4, 0), Quaternion.identity);
    }

    private IEnumerator DeraySpawnTime()
    {
        yield return new WaitForSeconds(1f);

        SpawnPlayer();
    }
}
