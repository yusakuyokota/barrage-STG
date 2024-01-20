using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �R���g���[���[���͂��Ǘ�����N���X
/// </summary>
public class ControllerManager : MonoBehaviour
{
    public static ControllerManager instance;

    public ControllerInput CtrlInput;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (CtrlInput == null)
        {
            CtrlInput = new ControllerInput();
            CtrlInput.Enable();
        }
    }
}
