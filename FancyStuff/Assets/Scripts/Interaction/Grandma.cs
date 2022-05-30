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
        public Sprite positiveOutcome;
        public Sprite negativeOutcome;
        
        private IMediator _mediator;

        private int _givenAmount = 0;
        private const int NeededAmount = 4;

        private readonly List<ItemType> _interactableType = new List<ItemType> { ItemType.AppleSlice, ItemType.Apple };
        private readonly List<ItemType> _interactableBadType = new List<ItemType> { ItemType.Knife };

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
            _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "I want to bake apple cake. Bring me some apples, please."});
        }

        public void ShowText()
        {
            _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "I want to bake apple cake. Bring me some apples, please."});
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
                    _givenAmount += 1;
                    _mediator.SetScore(3);
                    if (_givenAmount != NeededAmount)
                    {
                        _mediator.RemoveItemFromInventory(item.ItemType);
                        _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "I need more apples"});
                        return;
                    }
                    
                    _mediator.RemoveAndHideInventory(item);
                    _mediator.SetScore(30);
                    
                    gameObject.GetComponent<SpriteRenderer>().sprite = positiveOutcome;
                    
                    _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "Thank you!"});
                    
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
                
                gameObject.GetComponent<SpriteRenderer>().sprite = negativeOutcome;
            }
        }
    }
}