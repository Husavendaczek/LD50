using System.Collections.Generic;
using System.Linq;
using Helper;
using RoomScene;
using UnityEngine;

namespace World
{
    public class WorldItemManager : MonoBehaviour
    {
        public WorldMediator worldMediator;
        public WorldItemCreator worldItemCreator;
        public WorldItemsOfSceneLoader worldItemsOfSceneLoader;

        private readonly List<WorldItemMono> _currentViewableWorldItems = new List<WorldItemMono>();
        private int maximumId = 0;

        private void Start()
        {
            var worldItemsForScene = worldItemsOfSceneLoader.WorldItemsForCurrentScene();

            foreach (var worldItem in worldItemsForScene)
            {
                if (worldItem.Id > maximumId)
                {
                    maximumId = worldItem.Id;
                }
                _currentViewableWorldItems.Add(worldItemCreator.Create(worldItem));
            }
        }

        public void SetCollected(WorldItemMono worldItem)
        {
            if (!_currentViewableWorldItems.Any()) return;
            
            worldItemsOfSceneLoader.SetWorldItemToCollected(worldItem.id);
            
            _currentViewableWorldItems.Remove(worldItem);
            Destroy(worldItem.gameObject);
        }
    }
}