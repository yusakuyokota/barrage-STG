using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreateEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPre;
    
    [SerializeField]
    private Transform _rangeA;
    
    [SerializeField] 
    private Transform _rangeB;

    private float currentTime;
    private float tempInterval;

    private bool isTimeRunning = false;

    private void Start()
    {
        EnemySpwan(1);
    }

    private void EnemySpwan(float u)
    {
        isTimeRunning = true;
        this.currentTime = 0;
        StartCoroutine(IEEnemySpawn(u));
    }


    private IEnumerator IEEnemySpawn(float u)
    {
        this.tempInterval = u;

        var count = 0f;
        while (currentTime < 600f)
        {
            if (isTimeRunning)
            {
                this.currentTime += Time.deltaTime;
                count += Time.deltaTime;
            }
            else
            {
                break;
            }

            if (count > u)
            {
                float x = Random.Range(_rangeA.position.x, _rangeB.position.x);
                float y = Random.Range(_rangeA.position.y, _rangeB.position.y);

                Instantiate(_enemyPre, new Vector2(x, y), Quaternion.identity);
                count -= u;
            }
            yield return null;
        }
    }
}
