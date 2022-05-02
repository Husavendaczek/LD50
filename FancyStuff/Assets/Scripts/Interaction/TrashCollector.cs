using System;
using System.Collections.Generic;
using Achieving;
using Inventory;
using ItemProperty;
using Messaging;
using RoomScene;
using UnityEngine;

namespace Interaction
{
    public class TrashCollector : MonoBehaviour, IInteractable
    {
        public Sprite positiveOutcome;
        public Sprite negativeOutcome;
        
        private IMediator _mediator;
        private readonly List<ItemType> _interactableType = new List<ItemType> { ItemType.PaperTrash, ItemType.RottenBanana };
        private readonly List<ItemType> _interactableBadType = new List<ItemType> { ItemType.AppleSlice, ItemType.Apple, ItemType.CatFood };

        private void Start()
        {
            _mediator = FindObjectOfType<WorldMediator>();
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
            _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "Go, clean your room!"});
        }

        public void ShowText()
        {
            _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "Go, clean your room!"});
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
                _mediator.ShowAchievement(AchievementType.CleanedStevesRoom);
                _mediator.SetScore(5);
                
                gameObject.GetComponent<SpriteRenderer>().sprite = positiveOutcome;
            }
            else if (_interactableBadType.Contains(item.ItemType))
            {
                _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "Steven! Are you wasting food again?"});
                _mediator.SetScore(-5);
                
                gameObject.GetComponent<SpriteRenderer>().sprite = positiveOutcome;
            }
            else
            {
                _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "Take that out of the trash!"});
                _mediator.SetScore(-1);
                
                gameObject.GetComponent<SpriteRenderer>().sprite = negativeOutcome;
            }
        }
    }
}