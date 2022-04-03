using System.Collections.Generic;
using Achieving;
using Inventory;
using ItemProperty;
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
            _mediator.ShouldMove(false);
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
                    return;
                }
                //TODO show message: you should slice them
            }
            else if (_interactableBadType.Contains(item.ItemType))
            {
                //TODO show message: what is wrong with you? -> sad end
                _mediator.ShowHappyEnd(false);
                _mediator.ShowAchievement(AchievementType.GrandmaKiller);
            }
            else
            {
                //TODO show error text
            }
            _mediator.ShouldMove(true);
        }
    }
}