using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        void Update()
        {
            float score = GameManager.instance.GetScore();
            scoreText.text = score.ToString("F0");
        }
    }
}
