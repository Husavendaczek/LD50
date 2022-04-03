using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoomScene
{
    public static class SceneLoader
    {
        public static void GoToStevesRoom()
        {
            Debug.Log("go to steves room");
            SceneManager.LoadScene("StevesRoom");
        }

        public static void GoToKitchen()
        {
            Debug.Log("go to kitchen");
            SceneManager.LoadScene("Kitchen");
        }
        
        public static void GoToLivingRoom()
        {
            Debug.Log("go to living room");
            SceneManager.LoadScene("LivingRoom");
        }
        
        public static void GoToGarden()
        {
            Debug.Log("go to garden");
            SceneManager.LoadScene("Garden");
        }
    }
}