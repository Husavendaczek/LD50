using System.Collections.Generic;
using System.Linq;
using RoomScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class WorldItemsOfSceneLoader : MonoBehaviour
    {
        private SceneRoom _currentScene;

        private void Start()
        {
            var currentSceneName = SceneManager.GetActiveScene().name;
            var worldItemStore = FindObjectOfType<WorldItemStore>();

            if (currentSceneName == worldItemStore.StevesRoom.SceneName)
            {
                _currentScene = worldItemStore.StevesRoom;
            }
            else if (currentSceneName == worldItemStore.Kitchen.SceneName)
            {
                _currentScene = worldItemStore.Kitchen;
            }
            else
            {
                _currentScene = worldItemStore.StartScene;
            }
        }

        public List<WorldItem> WorldItemsForCurrentScene()
        {
            return _currentScene.WorldItems.Where(worldItem => worldItem.Collected == false).ToList();
        }

        public void SetWorldItemToCollected(int id)
        {
            var worldItem = _currentScene.WorldItems.Find(worldItem => worldItem.Id == id);
            worldItem.Collected = false;
        }
    }
}