using System.Collections.Generic;
using System.Linq;
using Helper;
using Inventory;
using UnityEngine;

namespace World
{
    public class WorldItemManager : MonoBehaviour
    {
        public WorldItemCreator worldItemCreator;
        public WorldItemsOfSceneLoader worldItemsOfSceneLoader;

        private readonly List<WorldItemMono> _currentViewableWorldItems = new List<WorldItemMono>();
        private int _maximumId = 0;

        private void Start()
        {
            InitWorldItems();
        }

        public void InitWorldItems()
        {
            ResetViewableWorldItems();
            
            var worldItemsForScene = worldItemsOfSceneLoader.WorldItemsForCurrentScene();

            foreach (var worldItem in worldItemsForScene)
            {
                if (worldItem.Id > _maximumId)
                {
                    _maximumId = worldItem.Id;
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
            //TODO fix bug
            if (worldItemsOfSceneLoader.ExistsInSceneRooms(id))
            {
                worldItemsOfSceneLoader.SetWorldItemCollected(id, false);
            }
            else
            {
                AddToWorldItems(id, itemType);
            }
        }

        public WorldItem AddToWorldItems(ItemType itemType)
        {
            return AddToWorldItems(_maximumId + 1, itemType);
        }

        private WorldItem AddToWorldItems(int id, ItemType itemType)
        {
            var worldItem = worldItemCreator.Create(id, itemType);
            worldItemsOfSceneLoader.AddToSceneRoom(worldItem.MapTo());
            _currentViewableWorldItems.Add(worldItem);
            return worldItem.MapTo();
        }

        private void ResetViewableWorldItems()
        {
            foreach (var currentViewableWorldItem in _currentViewableWorldItems)
            {
                Destroy(currentViewableWorldItem.gameObject);
            }
        }
    }
}