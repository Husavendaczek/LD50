using ItemProperty;
using UnityEngine;

namespace World
{
    public class WorldItemCreator : MonoBehaviour
    {
        public GameObject worldItemPrefab;

        public ItemIcons itemIcons;

        public void Create(WorldItem worldItem)
        {
            var tmp = GameObject.Find(worldItem.ItemType + worldItem.Id.ToString());
            if(tmp != null) return;
            
            var worldItemGameObject = Instantiate(worldItemPrefab, this.transform, true);
            worldItemGameObject.transform.position = worldItem.Position;
            Debug.Log("my scale is " + worldItem.ScaleSize);
            worldItemGameObject.transform.localScale = worldItem.ScaleSize;
            
            worldItemGameObject.name = worldItem.ItemType + worldItem.Id.ToString();
            worldItemGameObject.tag = "WorldItem";

            worldItemGameObject.GetComponent<SpriteRenderer>().sprite = itemIcons.icons[(int) worldItem.ItemType];
            
            worldItemGameObject.GetComponent<WorldItemMono>().id = worldItem.Id;
            worldItemGameObject.GetComponent<WorldItemMono>().itemType = worldItem.ItemType;
            worldItemGameObject.GetComponent<WorldItemMono>().position = worldItem.Position;
        }

        public WorldItemMono Create(int id, ItemType itemType, bool show)
        {
            var tmp = GameObject.Find(itemType + id.ToString());
            if(tmp != null) return tmp.GetComponent<WorldItemMono>();
            
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
            
            worldItemGameObject.SetActive(show);

            return worldItemGameObject.GetComponent<WorldItemMono>();
        }
    }
}