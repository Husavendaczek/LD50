using Inventory;

namespace Interaction
{
    public interface IInteractable
    {
        public void ShowContextMenu();

        public void ShowText();

        public void StartInteraction();

        public void Interact(InventoryItem item);
    }
}