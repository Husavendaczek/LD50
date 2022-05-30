using Inventory;
using Messaging;
using RoomScene;
using UnityEngine;

namespace Interaction
{
    public class Exit : MonoBehaviour, IInteractable
    {
        private IMediator _mediator;
        public void ShowContextMenu()
        {
            _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "End the game"});
        }

        public void ShowText()
        {
            _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "Grow up"});
        }

        public void StartInteraction()
        {
            _mediator.ShowSimpleMessage(new SimpleMessage {MessageText = "You should grow up"});
            _mediator.InteractionManagerHasSelectedItem(this);
        }

        public void Interact(InventoryItem item)
        {
            _mediator.ShowEnd();
        }
    }
}