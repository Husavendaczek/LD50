using RoomScene;
using UnityEngine;

namespace Inventory
{
    public class InventoryKeyManager : MonoBehaviour
    {
        public IMediator Mediator;
        public GameObject inventoryCanvas;

        private bool _showInventory = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
            {
                ShowInventory(!_showInventory);
            }
        }

        public void ShowInventory(bool show)
        {
            inventoryCanvas.SetActive(show);
            _showInventory = show;
            
            Mediator.PauseMovement(show);
        }
    }
}