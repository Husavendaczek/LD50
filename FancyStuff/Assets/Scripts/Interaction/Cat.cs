using System.Collections.Generic;
using Achieving;
using Inventory;
using ItemProperty;
using Messaging;
using RoomScene;
using UnityEngine;

namespace Interaction
{
    public class Cat : MonoBehaviour, IInteractable
    {
        private IMediator _mediator;
        
        private readonly List<ItemType> _interactableType = new List<ItemType> { ItemType.CatFood };
        private readonly List<ItemType> _interactableBadType = new List<ItemType> { ItemType.Clothes };

        private void Start()
        {
            _mediator = GameObject.FindWithTag("WorldMediator").GetComponent<WorldMediator>();
        }
        
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
            StartInteraction();
        }
        
        public void ShowContextMenu()
        {
            //TODO show context menu with speak
        }

        public void ShowText()
        {
            _mediator.ShowSimpleMessage(new SimpleMessage { MessageText = "Meow!"});
        }

        public void StartInteraction()
        {
            _mediator.InteractionManagerHasSelectedItem(this);
        }

        public void Interact(InventoryItem item)
        {
            Debug.Log("interact with " + item.ItemType);
            if (_interactableType.Contains(item.ItemType))
            {
                _mediator.RemoveAndHideInventory(item);
            }
            else if (_interactableBadType.Contains(item.ItemType))
            {
                _mediator.ShowAchievement(AchievementType.CatDresser);
            }
            else if (item.ItemType == ItemType.Knife)
            {
                _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "What is wrong with you?!"});
                _mediator.SetScore(-100000);
                _mediator.ShowEnd();
                _mediator.ShowAchievement(AchievementType.CatKiller);
            }
            else
            {
                _mediator.ShowSimpleMessage(new SimpleMessage { MessageText = "Meow! Meow!"});
            }
        }
    }
}