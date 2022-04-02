using Inventory;
using ItemProperty;
using RoomScene;
using UnityEngine;
using UnityEngine.UI;

namespace Interaction
{
    public class InteractionManager : MonoBehaviour
    {
        public IMediator Mediator;
        public GameObject hoverPrefab;

        private GameObject _firstSelectedGO;
        private InventoryItem _firstSelectedItem;

        public ItemIcons itemIcons;

        public void Interact(ItemType targetType)
        {
            if (_firstSelectedItem == null)
            {
                CreateDragUIItem(targetType);
                return;
            }

            var origintype = _firstSelectedItem.ItemType;

            if (InteractingWith(origintype, targetType, ItemType.Apple, ItemType.Knife))
            {
                //TODO create
                Mediator.RemoveItemFromInventory(origintype);
                Mediator.RemoveItemFromInventory(targetType);

                DeleteFirst();
            }
        }
        
        private bool InteractingWith(ItemType originType, ItemType targetType, ItemType interactableA, ItemType interactableB)
        {
            return originType == interactableA && targetType == interactableB ||
                   originType == interactableB && targetType == interactableA;
        }

        private void CreateDragUIItem(ItemType itemType)
        {
            if (_firstSelectedGO == null)
            {
                var myCanvas = GameObject.FindWithTag("InventoryPanel");
                _firstSelectedGO = Instantiate(hoverPrefab, myCanvas.transform, true);
                _firstSelectedGO.transform.position = myCanvas.transform.position;
                _firstSelectedItem = Mediator.FirstInventoryItem(itemType);
            }
            
            _firstSelectedGO.SetActive(true);
            _firstSelectedGO.GetComponent<Image>().sprite = itemIcons.icons[(int) itemType];
        }
        
        private void DeleteFirst()
        {
            Destroy(_firstSelectedGO);
            _firstSelectedItem = null;
        }
    }
}