using UnityEngine;

namespace MiniGames
{
    public class MiniGameStore : MonoBehaviour
    {
        public Sprite[] backgrounds;
        
        public MiniGame AppleGame = new MiniGame
        {
            GameName = "AppleMiniGame",
            BackgroundValue = 0
        };
    }
}