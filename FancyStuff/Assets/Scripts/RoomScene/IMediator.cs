using Inventory;
using World;

namespace RoomScene
{
    public interface IMediator
    {
        void CollectItem(WorldItemMono worldItemMono);

        void DropItemBackToWorld(int id, ItemType itemType);

        void RemoveItemFromInventory(ItemType itemType);

        void RemoveAndHideInventory(InventoryItem item);

        void PauseMovement(bool pause);

        void ShowInventory(bool show);
    }
}