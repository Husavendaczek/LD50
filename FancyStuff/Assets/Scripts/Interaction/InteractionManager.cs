using System;
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

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if(_firstSelectedGO == null) return;
            
            var gameCanvas = GameObject.FindWithTag("GameCanvas").GetComponent<Canvas>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(gameCanvas.transform as RectTransform, Input.mousePosition, gameCanvas.worldCamera, out var pos);
            var newPos = gameCanvas.transform.TransformPoint(pos);
            _firstSelectedGO.transform.position = new Vector3(newPos.x + 30f, newPos.y - 20, newPos.z);
        }

        public void Interact(ItemType targetType)
        {
            Debug.Log("Real interaction");
            if (_firstSelectedItem == null)
            {
                CreateDragUIItem(targetType);
            }

            var origintype = _firstSelectedItem.ItemType;

            if (InteractingWith(origintype, targetType, ItemType.Apple, ItemType.Knife))
            {
                Mediator.CreateItemInWorld(ItemType.AppleSlice);
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
                var gameCanvas = FindObjectOfType<InventoryPanelManager>().InventoryPanel;
                _firstSelectedGO = Instantiate(hoverPrefab, gameCanvas.transform, true);
                _firstSelectedGO.transform.position = gameCanvas.transform.position;
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

        public void HasSelectedItem(IInteractable interactable)
        {
            if (_firstSelectedItem == null)
            {
                interactable.ShowContextMenu();
                return;
            }
            
            interactable.Interact(_firstSelectedItem);
            DeleteFirst();
        }
    }
}