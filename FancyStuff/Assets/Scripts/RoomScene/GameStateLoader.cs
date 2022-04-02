using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoomScene
{
    public class GameStateLoader : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("StevesRoom");
        }
        
        public void ShowHappyEnd()
        {
            SceneManager.LoadScene("HappyEnd");
        }
        
        public void ShowSadEnd()
        {
            SceneManager.LoadScene("SadEnd");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}