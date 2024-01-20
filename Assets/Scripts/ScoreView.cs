using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public void ScoreTextUpdate(int score)
    {
        scoreText.text = score.ToString();
    }
}
