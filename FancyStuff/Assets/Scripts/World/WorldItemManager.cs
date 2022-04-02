using System.Collections.Generic;
using System.Linq;
using Helper;
using Inventory;
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

        public void CollectFromWorld(WorldItemMono worldItem)
        {
            if (!_currentViewableWorldItems.Any()) return;
            
            worldItemsOfSceneLoader.SetWorldItemCollected(worldItem.id, true);
            
            _currentViewableWorldItems.Remove(worldItem);
            Destroy(worldItem.gameObject);
        }

        public void DropIntoWorld(int id, ItemType itemType)
        {
            if (worldItemsOfSceneLoader.ExistsInSceneRooms(id))
            {
                worldItemsOfSceneLoader.SetWorldItemCollected(id, false);
            }
            else
            {
                var worldItem = worldItemCreator.Create(id, itemType);
                worldItemsOfSceneLoader.AddToSceneRoom(worldItem.MapTo());
            }

        }
    }
}