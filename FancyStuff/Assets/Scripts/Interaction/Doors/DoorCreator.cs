using UnityEngine;

namespace Interaction.Doors
{
    public class DoorCreator : MonoBehaviour
    {
        public GameObject DoorPrefab;
        public Sprite doorSprite;

        public void Create(Door door, Transform transform)
        {
            var doorGameObject = Instantiate(DoorPrefab, transform, true);
            doorGameObject.transform.position = door.Position;

            doorGameObject.GetComponent<SpriteRenderer>().sprite = doorSprite;
            doorGameObject.GetComponent<DoorMono>().enteredRoomPosition = door.EnteredRoomPosition;
            doorGameObject.GetComponent<DoorMono>().GoToRoom = door.GoToRoom;
        }
    }
}