using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Vector3 _pos;

    private void Start()
    {
        _pos = transform.position;
    }

    private void Update()
    {
        transform.position = _pos;
    }
}
