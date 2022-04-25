using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoomScene
{
    public static class SceneLoader
    {
        public static void GoToStevesRoom()
        {
            SceneManager.LoadScene("StevesRoom");
        }

        public static void GoToKitchen()
        {
            SceneManager.LoadScene("Kitchen");
        }
        
        public static void GoToLivingRoom()
        {
            SceneManager.LoadScene("LivingRoom");
        }
        
        public static void GoToGarden()
        {
            SceneManager.LoadScene("Garden");
        }
    }
}