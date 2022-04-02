using Inventory;
using World;

namespace RoomScene
{
    public interface IMediator
    {
        void CreateItemInWorld(ItemType itemType);
        
        void CollectItem(WorldItemMono worldItemMono);

        void DropItemBackToWorld(int id, ItemType itemType);

        void RemoveItemFromInventory(ItemType itemType);

        void RemoveAndHideInventory(InventoryItem item);

        InventoryItem FirstInventoryItem(ItemType itemType);

        void StartInteraction(ItemType itemType);

        void PauseMovement(bool pause);

        void ShowInventory(bool show);
    }
}