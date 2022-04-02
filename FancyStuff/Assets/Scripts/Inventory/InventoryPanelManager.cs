using UnityEngine;

namespace Inventory
{
    public class InventoryPanelManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}