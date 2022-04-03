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
        public GameObject interactionButton;
        public GameObject removeButton;
    }
}