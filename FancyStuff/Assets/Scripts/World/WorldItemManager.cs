using System.Linq;
using Helper;
using ItemProperty;
using UnityEngine;

namespace World
{
    public class WorldItemManager : MonoBehaviour
    {
        public WorldItemCreator worldItemCreator;
        public WorldItemsOfSceneLoader worldItemsOfSceneLoader;

        private int _maximumId = 0;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            InitWorldItems();
        }

        public void InitWorldItems()
        {
            Debug.Log("init world items");
            var worldItemsForScene = worldItemsOfSceneLoader.WorldItemsForCurrentScene();

            foreach (var worldItem in worldItemsForScene)
            {
                worldItemCreator.Create(worldItem);
                if (worldItem.Id > _maximumId)
                {
                    _maximumId = worldItem.Id;
                }
            }
        }

        public void CollectFromWorld(WorldItemMono worldItem)
        {
            if (!worldItemsOfSceneLoader.WorldItemsForCurrentScene().Any()) return;

            worldItemsOfSceneLoader.SetWorldItemCollected(worldItem.id, true);
            
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
                AddToWorldItems(id, itemType);
            }
        }

        public WorldItem AddToWorldItems(ItemType itemType)
        {
            return AddToWorldItems(_maximumId + 1, itemType, false);
        }

        private WorldItem AddToWorldItems(int id, ItemType itemType, bool show = true)
        {
            var worldItem = worldItemCreator.Create(id, itemType, show);
            worldItemsOfSceneLoader.AddToSceneRoom(worldItem.MapTo());
            return worldItem.MapTo();
        }
    }
}