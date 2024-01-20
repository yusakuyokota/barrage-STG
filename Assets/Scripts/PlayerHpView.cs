using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class PlayerHpView : MonoBehaviour
{
    [SerializeField]
    private Image heart;

    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.Life;  i++)
        {
            var tmpHeart = Instantiate(heart);

            tmpHeart.transform.SetParent(transform);

            tmpHeart.transform.localScale = Vector3.one;
        }
    }
}
