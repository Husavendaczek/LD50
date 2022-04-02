using RoomScene;
using UnityEngine;

namespace Interaction.Doors
{
    public class AllDoors : MonoBehaviour
    {
        public Door StevensRoomDoorMono = new Door
        {
            Position = new Vector3(8.38f, -1.15f, 0),
            EnteredRoomPosition = new Vector3(6.38f, -1.15f, 0)
        };
        
        public Door GardenToKitchenDoor = new Door
        {
            Position = new Vector3(-0.13f, 4.7f, 0),
            EnteredRoomPosition = new Vector3(-0.13f, -1.25f, 0),
        };
        public Door KitchenToGardenDoor = new Door
        {
            Position = new Vector3(-0.13f, -2.7f, 0),
            EnteredRoomPosition = new Vector3(-0.13f, 3.5f, 0),
        };
        public Door KitchenToLivingRoomDoor = new Door
        {
            Position = new Vector3(8.38f, -1.15f, 0),
            EnteredRoomPosition = new Vector3(6.38f, -1.15f, 0)
        };
        public Door KitchenToStevensRoomDoor = new Door
        {
            Position = new Vector3(-8.38f, -1.15f, 0),
            EnteredRoomPosition = new Vector3(-6.38f, -1.15f, 0)
        };
        
        public Door LivingRoomToKitchenDoor = new Door
        {
            Position = new Vector3(-8.38f, -1.15f, 0),
            EnteredRoomPosition = new Vector3(-6.38f, -1.15f, 0)
        };

        private void Start()
        {
            var sceneLoader = FindObjectOfType<SceneLoader>();
            
            StevensRoomDoorMono.GoToRoom = () => {
                sceneLoader.GoToKitchen();
            };
            GardenToKitchenDoor.GoToRoom = () => {
                sceneLoader.GoToKitchen();
            };
            KitchenToGardenDoor.GoToRoom = () => {
                sceneLoader.GoToGarden();
            };
            KitchenToLivingRoomDoor.GoToRoom = () => {
                sceneLoader.GoToLivingRoom();
            };
            KitchenToStevensRoomDoor.GoToRoom = () => {
                sceneLoader.GoToStevesRoom();
            };
            LivingRoomToKitchenDoor.GoToRoom = () => {
                sceneLoader.GoToKitchen();
            };
        }
    }
}