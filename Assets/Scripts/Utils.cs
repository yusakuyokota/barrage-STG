using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    /// <summary>
    /// 与えられた角度からベクトルを返す関数
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static Vector3 GetDirection(float angle)
    {
        return new Vector3
            (
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad),
                0
            );
    }
}
