using System.Collections.Generic;
using System.Linq;
using RoomScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class WorldItemsOfSceneLoader : MonoBehaviour
    {
        private WorldItemStore _worldItemStore;
        private SceneRoom _currentScene;

        private void Start()
        {
            var currentSceneName = SceneManager.GetActiveScene().name;
            _worldItemStore = FindObjectOfType<WorldItemStore>();

            if (currentSceneName == _worldItemStore.StevesRoom.SceneName)
            {
                _currentScene = _worldItemStore.StevesRoom;
            }
            else if (currentSceneName == _worldItemStore.Kitchen.SceneName)
            {
                _currentScene = _worldItemStore.Kitchen;
            }
            else
            {
                _currentScene = _worldItemStore.StartScene;
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

        public void SetBackgroundOfScene()
        {
            GameObject background = GameObject.FindWithTag("Background");
            background.GetComponent<SpriteRenderer>().sprite = _worldItemStore.backgrounds[_currentScene.BackgroundValue];
        }
    }
}