using UnityEngine;
using UnityEngine.UI;

namespace Common.Code.Score
{
    public class ScoreBehaviour : MonoBehaviour
    {
        private static ScoreBehaviour instance;
        public Text scoreText;
        private int score = 0;

        private void Awake() => 
            instance = this;
        
        private void Start() => 
            scoreText.text = score.ToString();

        public ScoreBehaviour GetInstance() => 
            instance;

        public void AddPoint()
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }
}