using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Vector2 pos;

    private void Start()
    {
        pos = transform.position;
    }

    private void Update()
    {
        transform.position = pos;
    }
}
