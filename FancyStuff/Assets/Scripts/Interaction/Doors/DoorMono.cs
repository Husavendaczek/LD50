using System;
using Inventory;
using UnityEngine;

namespace Interaction.Doors
{
    public class DoorMono : MonoBehaviour
    {
        public string doorName;
        public Action GoToRoom;
        public Vector3 enteredRoomPosition;
        public Sprite sprite;

        public void GoTo()
        {
            GoToRoom();
        }
        
        private void OnMouseOver()
        {
            var keyManager = FindObjectOfType<InventoryKeyManager>();
            if (keyManager.IsInventoryVisible()) return;
            
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(200,200,200, 255);
        }

        private void OnMouseExit()
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}