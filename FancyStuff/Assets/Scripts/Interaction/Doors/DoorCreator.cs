using UnityEngine;

namespace Interaction.Doors
{
    public class DoorCreator : MonoBehaviour
    {
        public GameObject doorPrefab;
        public Sprite doorSprite;

        public void Create(Door door, Transform parentTransform)
        {
            var tmp = GameObject.Find(door.DoorName);
            if(tmp != null) return;
            
            var doorGameObject = Instantiate(doorPrefab, parentTransform, true);
            doorGameObject.name = door.DoorName;
            doorGameObject.transform.position = door.Position;
            doorGameObject.tag = "Door";

            doorGameObject.GetComponent<SpriteRenderer>().sprite = doorSprite;
            doorGameObject.GetComponent<DoorMono>().enteredRoomPosition = door.EnteredRoomPosition;
            doorGameObject.GetComponent<DoorMono>().GoToRoom = door.GoToRoom;
            doorGameObject.GetComponent<DoorMono>().doorName = door.DoorName;
        }
    }
}