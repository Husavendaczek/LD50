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
            worldItemGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            
            worldItemGameObject.name = worldItem.ItemType + worldItem.Id.ToString();

            worldItemGameObject.GetComponent<SpriteRenderer>().sprite = itemIcons.icons[(int) worldItem.ItemType];
            
            worldItemGameObject.GetComponent<WorldItemMono>().id = worldItem.Id;
            worldItemGameObject.GetComponent<WorldItemMono>().itemType = worldItem.ItemType;
            worldItemGameObject.GetComponent<WorldItemMono>().position = worldItem.Position;

            return worldItemGameObject.GetComponent<WorldItemMono>();
        }
    }
}