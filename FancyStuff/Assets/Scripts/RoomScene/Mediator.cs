using Helper;
using Inventory;
using ItemProperty;
using UnityEngine;
using World;

namespace RoomScene
{
    public class Mediator : MonoBehaviour
    {
        private InventoryManager _inventoryManager;
        private WorldItemManager _worldItemManager;
        private WorldItemsOfSceneLoader _worldItemsOfSceneLoader;

        private void Awake()
        {
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _inventoryManager.mediator = this;
            _inventoryManager.inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryManager.inventoryCreator = FindObjectOfType<InventoryCreator>();
            _inventoryManager.inventoryCreator.ItemIcons = FindObjectOfType<ItemIcons>();
            
            _worldItemsOfSceneLoader = FindObjectOfType<WorldItemsOfSceneLoader>();
            
            _worldItemManager = FindObjectOfType<WorldItemManager>();
            _worldItemManager.mediator = this;
            _worldItemManager.worldItemCreator = FindObjectOfType<WorldItemCreator>();
            _worldItemManager.worldItemCreator.itemIcons = FindObjectOfType<ItemIcons>();
            _worldItemManager.worldItemsOfSceneLoader = _worldItemsOfSceneLoader;
        }

        public void CollectItem(WorldItemMono worldItemMono)
        {
            _inventoryManager.Collect(worldItemMono.MapTo());
            _worldItemManager.SetCollected(worldItemMono);
        }
    }
}