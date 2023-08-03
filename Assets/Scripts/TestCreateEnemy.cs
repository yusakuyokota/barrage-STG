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
    private float tempInterval = 1;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime < tempInterval) return;

        float x = Random.Range(_rangeA.position.x, _rangeB.position.x);
        float y = Random.Range(_rangeA.position.y, _rangeB.position.y);

        Instantiate(_enemyPre, new Vector2(x, y), Quaternion.identity);
        currentTime = 0;
    }
}
