using Achieving;
using Interaction;
using Interaction.Doors;
using Inventory;
using ItemProperty;
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

        void ShouldMove(bool pause);

        void ShowInventory(bool show);
        
        void SceneSwitchFromDoor(DoorMono doorItem);

        void ShowAchievement(AchievementType type);
        void ShowHappyEnd(bool happy);
        void InteractionManagerHasSelectedItem(IInteractable interactable);
    }
}