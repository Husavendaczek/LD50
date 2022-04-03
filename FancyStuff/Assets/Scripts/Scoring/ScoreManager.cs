using UnityEngine;

namespace Scoring
{
    public class ScoreManager : MonoBehaviour
    {
        public int score = 0;

        public bool IsHappyEnd()
        {
            return score > 10;
        }

        public void SetScore(int value)
        {
            score += value;
        }
    }
}