using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItemSlot : MonoBehaviour
    {
        public InventoryItem Item;
        public int amount;
        public GameObject amountText;
        public Image icon;
        public Action interact;
        public Action remove;

        public void Interact()
        {
            Debug.Log("interact!!!!");
            interact();
        }

        public void Remove()
        {
            Debug.Log("remove!!!!");
            remove();
        }
    }
}