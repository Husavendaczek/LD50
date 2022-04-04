using System.Collections.Generic;
using Achieving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoomScene
{
    public class SadEndSceneResetter : MonoBehaviour
    {
        private List<Achievement> achievements = new List<Achievement>();
        private void Awake()
        {
            var achievementManager = FindObjectOfType<AchievementManager>();
            achievements = achievementManager.CompleteAchievements();
            
            var world = GameObject.Find("World");
            var gameCanvas = GameObject.Find("GameCanvas");
            var inventoryStore = GameObject.Find("InventoryStore");
            var worldMediator = GameObject.Find("WorldMediator");
            Destroy(worldMediator.gameObject);
            Destroy(world.gameObject);
            Destroy(gameCanvas.gameObject);
            Destroy(inventoryStore.gameObject);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("StartScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ShowAchievements()
        {
            foreach (var achievement in achievements)
            {
                //TODO show
            }
        }
    }
}