using System.Collections;
using TMPro;
using UnityEngine;

namespace BSWCarrom
{
    public class ScoreController : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;

        private int score = 0;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            RefreshUI();
        }

        //the score will increase by 10 points after each key collect
        public void IncreaseScore(int increament)
        {
            score += increament;
            RefreshUI();
            Debug.Log("increase");
        }

        private void RefreshUI()
        {
            scoreText.text = "Score: " + score;
        }
    }
}