using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Utils
{
    public static float XAxisMiddle = -4.2f;

    // 子要素にのみアタッチされている任意のコンポーネントを取得
    public static T GetComponentOnlyChildren<T>(this Transform t)
    {
        return t.GetComponentInChildren<T>();
    }

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
