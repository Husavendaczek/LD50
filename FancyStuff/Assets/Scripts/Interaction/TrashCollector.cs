using System.Collections.Generic;
using Achieving;
using Inventory;
using RoomScene;
using UnityEngine;

namespace Interaction
{
    public class TrashCollector : MonoBehaviour, IInteractable
    {
        public IMediator Mediator;
        private readonly List<ItemType> _interactableType = new List<ItemType> { ItemType.PaperTrash };
        
        public void ShowContextMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ShowText()
        {
            throw new System.NotImplementedException();
        }

        public void StartInteraction()
        {
            throw new System.NotImplementedException();
        }

        public void Interact(InventoryItem item)
        {
            if (_interactableType.Contains(item.ItemType))
            {
                Mediator.RemoveAndHideInventory(item);
                Mediator.ShowAchievement(AchievementType.CleanedStevesRoom);
            }
            else
            {
                //TODO show error text
            }
        }
    }
}