using UnityEngine;

namespace Inventory
{
    public class InventoryPanelManager : MonoBehaviour
    {
        public GameObject InventoryPanel;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}