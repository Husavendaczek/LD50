using UnityEngine;

namespace Interaction.Doors
{
    public class DoorCreator : MonoBehaviour
    {
        public GameObject doorPrefab;
        public Sprite doorSprite;

        public DoorMono Create(Door door, Transform parentTransform)
        {
            var doorGameObject = Instantiate(doorPrefab, parentTransform, true);
            doorGameObject.name = door.DoorName;
            doorGameObject.transform.position = door.Position;
            doorGameObject.tag = "Door";

            doorGameObject.GetComponent<SpriteRenderer>().sprite = doorSprite;
            doorGameObject.GetComponent<DoorMono>().enteredRoomPosition = door.EnteredRoomPosition;
            doorGameObject.GetComponent<DoorMono>().GoToRoom = door.GoToRoom;
            
            return doorGameObject.GetComponent<DoorMono>();
        }
    }
}