using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoomScene
{
    public class SceneLoader : MonoBehaviour
    {
        public void GoToStevesRoom()
        {
            SceneManager.LoadScene("StevesRoom");
        }

        public void GoToKitchen()
        {
            SceneManager.LoadScene("Kitchen");
        }
        
        public void GoToLivingRoom()
        {
            SceneManager.LoadScene("LivingRoom");
        }
        
        public void GoToGarden()
        {
            SceneManager.LoadScene("Garden");
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