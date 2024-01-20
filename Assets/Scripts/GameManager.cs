using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static object _lock = new object();

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance
                        = FindObjectOfType<GameManager>();
                    if (instance == null ) 
                    {
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<GameManager>();
                        singletonObject.name = nameof(GameManager) + "(singleton)";
                    }
                }

                return instance;
            }
        }
    }

    private GameObject objPlayer = null;

    private GameObject objEnemy = null;

    [SerializeField]
    private ScoreView scoreView;

    private Vector3 playerSpawnPos = new Vector3(Utils.XAxisMiddle, -4, 0);

    private bool isPlayerDie = false;

    private bool isEnemyDie = false;

    [SerializeField]
    private int life = 3;

    public int Life => life;

    private int score = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    private void Start()
    {
        scoreView.ScoreTextUpdate(score);

        SpawnPlayer();
        SpawnEnemy();
    }

    private void Update()
    {
        if (isPlayerDie && objPlayer != null)
        {
            Destroy(objPlayer);

            BulletDestroy();

            StartCoroutine(ReSpawn());
        }

        if (isEnemyDie && objEnemy != null)
        {
            Destroy(objEnemy);

            BulletDestroy();
        }
    }

    #region ì‡ïîèàóù

    private void SpawnPlayer()
    {
        isPlayerDie = false;
        var obj = Resources.Load<GameObject>("Prefabs/Player");

        if (objPlayer != null) return;

        objPlayer = Instantiate(obj, playerSpawnPos, Quaternion.identity);
    }

    private void SpawnEnemy()
    {
        var obj = Resources.Load<GameObject>("Prefabs/Enemy");
        objEnemy = Instantiate(obj, new Vector3(Utils.XAxisMiddle, 4, 0), Quaternion.identity);
    }

    private IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(1f);

        SpawnPlayer();
    }

    private void BulletDestroy()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    #endregion

    #region äOïîéQè∆èàóù

    public void SetPlayerDie() { isPlayerDie = true; }

    public void SetEnemyDie() { isEnemyDie = true; }
    public bool GetPlayerDie() { return isPlayerDie; }

    public void ScoreUpdate(int plusScore)
    {
        score += plusScore;
        scoreView.ScoreTextUpdate(score);
    }

    #endregion
}
