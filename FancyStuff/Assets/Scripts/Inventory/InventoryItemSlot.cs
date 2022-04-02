using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItemSlot : MonoBehaviour
    {
        public InventoryItem Item;
        public int amount;
        public Text amountText;
        public Image icon;
        public Action interact;
        public Action remove;

        public void Interact()
        {
            interact();
        }

        public void Remove()
        {
            remove();
        }
    }
}