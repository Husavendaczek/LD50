using Helper;
using Inventory;
using ItemProperty;
using UnityEngine;

namespace World
{
    public class WorldItemCreator : MonoBehaviour
    {
        public GameObject worldItemPrefab;

        public ItemIcons itemIcons;

        public WorldItemMono Create(WorldItem worldItem)
        {
            var worldItemGameObject = Instantiate(worldItemPrefab, this.transform, true);
            worldItemGameObject.transform.position = worldItem.Position;
            worldItemGameObject.transform.localScale = new Vector3(1f, 1f, 1);
            
            worldItemGameObject.name = worldItem.ItemType + worldItem.Id.ToString();
            worldItemGameObject.tag = "WorldItem";

            worldItemGameObject.GetComponent<SpriteRenderer>().sprite = itemIcons.icons[(int) worldItem.ItemType];
            
            worldItemGameObject.GetComponent<WorldItemMono>().id = worldItem.Id;
            worldItemGameObject.GetComponent<WorldItemMono>().itemType = worldItem.ItemType;
            worldItemGameObject.GetComponent<WorldItemMono>().position = worldItem.Position;

            return worldItemGameObject.GetComponent<WorldItemMono>();
        }

        public WorldItemMono Create(int id, ItemType itemType)
        {
            var position = new Vector3(0.0f, 0.1f, 0.0f);
            
            var worldItemGameObject = Instantiate(worldItemPrefab, this.transform, true);
            worldItemGameObject.transform.position = position;
            worldItemGameObject.transform.localScale = new Vector3(1f, 1f, 1);
            
            worldItemGameObject.name = itemType + id.ToString();
            worldItemGameObject.tag = "WorldItem";

            worldItemGameObject.GetComponent<SpriteRenderer>().sprite = itemIcons.icons[(int) itemType];
            
            worldItemGameObject.GetComponent<WorldItemMono>().id = id;
            worldItemGameObject.GetComponent<WorldItemMono>().itemType = itemType;
            worldItemGameObject.GetComponent<WorldItemMono>().position = position;

            return worldItemGameObject.GetComponent<WorldItemMono>();
        }
    }
}