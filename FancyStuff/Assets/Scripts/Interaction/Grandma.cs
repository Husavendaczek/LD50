using System.Collections.Generic;
using Achieving;
using Inventory;
using ItemProperty;
using Messaging;
using RoomScene;
using UnityEngine;

namespace Interaction
{
    public class Grandma : MonoBehaviour, IInteractable
    {
        private IMediator _mediator;
        
        private readonly List<ItemType> _interactableType = new List<ItemType> { ItemType.AppleSlice, ItemType.Apple };
        private readonly List<ItemType> _interactableBadType = new List<ItemType> { ItemType.Knife };

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
            //TODO show message
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
                if (item.ItemType == ItemType.AppleSlice)
                {
                    _mediator.RemoveAndHideInventory(item);
                    _mediator.SetScore(30);
                    _mediator.ShowEnd();
                    return;
                }
                _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "You should slice them!"});
            }
            else if (_interactableBadType.Contains(item.ItemType))
            {
                _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "What is wrong with you?!"});
                _mediator.SetScore(-100000);
                _mediator.ShowEnd();
                _mediator.ShowAchievement(AchievementType.GrandmaKiller);
            }
            else
            {
                _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "What should I do with that?"});
                _mediator.SetScore(-2);
            }
        }
    }
}