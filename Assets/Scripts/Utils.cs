using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Utils
{
    public static float XAxisMiddle = -4.2f;

    // �q�v�f�ɂ̂݃A�^�b�`����Ă���C�ӂ̃R���|�[�l���g���擾
    public static T GetComponentOnlyChildren<T>(this Transform t)
    {
        return t.GetComponentInChildren<T>();
    }

    /// <summary>
    /// �^����ꂽ�p�x����x�N�g����Ԃ��֐�
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
