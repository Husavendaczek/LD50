using System;
using System.Collections.Generic;
using System.Linq;
using Interaction;
using Interaction.Doors;
using RoomScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class WorldItemsOfSceneLoader : MonoBehaviour
    {
        private WorldItemStore _worldItemStore;
        private SceneRoom _currentScene;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            SceneManager.sceneLoaded += (scene, mode) => InitCurrentScene();
            
            if (_currentScene != null) return;
            
            InitCurrentScene();
        }

        public void InitCurrentScene()
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
            else if (currentSceneName == _worldItemStore.LivingRoom.SceneName)
            {
                _currentScene = _worldItemStore.LivingRoom;
            }
            else if (currentSceneName == _worldItemStore.Garden.SceneName)
            {
                _currentScene = _worldItemStore.Garden;
            }
            else
            {
                _currentScene = _worldItemStore.StartScene;
            }
            
            Debug.Log("Current Scene is " + _currentScene.SceneName);

            SetBackgroundOfScene();
        }

        public List<WorldItem> WorldItemsForCurrentScene()
        {
            if (_currentScene == null)
            {
                InitCurrentScene();
            }
            
            _worldItemStore.DestroyOldWorldItems(_currentScene);

            return _currentScene.WorldItems.Where(worldItem => worldItem.Collected == false).ToList();
        }

        public IEnumerable<Door> DoorsForCurrentScene()
        {
            if (_currentScene == null)
            {
                InitCurrentScene();
            }
            
            _worldItemStore.DestroyOldDoors(_currentScene);

            return _currentScene.ExistingDoors;
        }
        
        public IEnumerable<InteractableObj> InteractablesForCurrentScene()
        {
            if (_currentScene == null)
            {
                InitCurrentScene();
            }

            _worldItemStore.DestroyOldInteractables(_currentScene);
            
            return _currentScene.InteractableObjs;
        }

        public bool ExistsInSceneRooms(int id)
        {
            var exists = false;
            var allScenes = _worldItemStore.AllSceneRooms();
            foreach (var tmp in allScenes.Select(sceneRoom => sceneRoom.WorldItems.Where(worldItem => worldItem.Id == id).ToList()))
            {
                exists = tmp.Any();
            }
            return exists;
        }

        public void SetWorldItemCollected(int id, bool collected)
        {
            var worldItem = _currentScene.WorldItems.Find(worldItem => worldItem.Id == id);
            worldItem.Collected = collected;
        }

        public void AddToSceneRoom(WorldItem worldItem)
        {
            //TODO check if items are really added?
            _currentScene.WorldItems.Add(worldItem);
            
            var myCollection = _worldItemStore.AllSceneRooms().FirstOrDefault(room => room.SceneName == _currentScene.SceneName);
            var myWorldItems = myCollection.WorldItems;
            foreach (var myItem in myWorldItems)
            {
                Debug.Log(myItem.ItemType + ", id: " + myItem.Id);
            }
        }

        public void SetBackgroundOfScene()
        {
            GameObject background = GameObject.FindWithTag("Background");
            background.GetComponent<SpriteRenderer>().sprite = _worldItemStore.backgrounds[_currentScene.BackgroundValue];
        }
    }
}