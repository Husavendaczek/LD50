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
        public InteractionManager interactionManager;
        private readonly List<ItemType> _interactableType = new List<ItemType> { ItemType.PaperTrash };
        
        private void OnMouseOver()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(200,200,200, 255);
        }

        private void OnMouseExit()
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        private void OnMouseDown()
        {
            Mediator.ShouldMove(false);
            StartInteraction();
        }
        
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
            Debug.Log("start interaction with trash");
            interactionManager.HasSelectedItem(this);
        }

        public void Interact(InventoryItem item)
        {
            Debug.Log("interact with " + item.ItemType);
            if (_interactableType.Contains(item.ItemType))
            {
                Mediator.RemoveAndHideInventory(item);
                Mediator.ShowAchievement(AchievementType.CleanedStevesRoom);
            }
            else
            {
                //TODO show error text
            }
            Mediator.ShouldMove(true);
        }
    }
}