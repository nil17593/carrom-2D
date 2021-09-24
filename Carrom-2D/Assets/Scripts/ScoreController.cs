using System.Collections;
using TMPro;
using UnityEngine;

namespace BSWCarrom
{
    public class ScoreController : GenericMonoSingleton<ScoreController>
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score = 0;

        private void Start()
        {
            RefreshUI();

        }

        //the score will increase by respective points after each coin collect
        public void IncreaseScore(int increament)
        {
            score += increament;
            RefreshUI();
            Debug.Log("increase");
        }

        //score text will refresh after every score update
        private void RefreshUI()
        {
            scoreText.text = "Score: " + score;
        }
    }
}