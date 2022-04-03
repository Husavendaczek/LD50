using System.Collections.Generic;
using Interaction.Doors;
using Inventory;
using RoomScene;
using UnityEngine;

namespace World
{
    public class WorldItemStore : MonoBehaviour
    {
        public Sprite[] backgrounds;
        public SceneRoom StartScene = new()
        {
            SceneName = "StartScene",
            ExistingDoors = new List<Door>(),
            BackgroundValue = 0,
            WorldItems = new List<WorldItem>()
        };
        
        public SceneRoom StevesRoom = new()
        {
            SceneName = "StevesRoom",
            BackgroundValue = 1,
            ExistingDoors = new List<Door>
            {
                new()
                {
                    DoorName = "StevesRoomDoor",
                    Position = new Vector3(8.38f, -1.15f, 0),
                    EnteredRoomPosition = new Vector3(-6.38f, -1.15f, 0),
                    GoToRoom = SceneLoader.GoToKitchen
                }
            },
            WorldItems = new List<WorldItem>
            {
                new()
                {
                    Id = 0,
                    Position = new Vector3(8,0,0),
                    ItemType = ItemType.PaperTrash,
                    Collected = false
                },
                new()
                {
                    Id = 1,
                    Position = new Vector3(1,1,0),
                    ItemType = ItemType.PaperTrash,
                    Collected = false
                },
                new()
                {
                    Id = 2,
                    Position = new Vector3(7,1,0),
                    ItemType = ItemType.CatFood,
                    Collected = false
                },
            }
        };
        
        public SceneRoom Kitchen = new()
        {
            SceneName = "Kitchen",
            BackgroundValue = 2,
            ExistingDoors = new List<Door>
            {
                new()
                {
                    DoorName = "KitchenToStevesRoomDoor",
                    Position = new Vector3(-8.38f, -1.15f, 0),
                    EnteredRoomPosition = new Vector3(6.38f, -1.15f, 0),
                    GoToRoom = SceneLoader.GoToStevesRoom
                },
                new()
                {
                    DoorName = "KitchenToGardenDoor",
                    Position = new Vector3(-0.13f, -2.7f, 0),
                    EnteredRoomPosition = new Vector3(-0.13f, 3.5f, 0),
                    GoToRoom = SceneLoader.GoToGarden
                },
                new()
                {
                    DoorName = "KitchenToLivingRoomDoor",
                    Position = new Vector3(8.38f, -1.15f, 0),
                    EnteredRoomPosition = new Vector3(-6.38f, -1.15f, 0),
                    GoToRoom = SceneLoader.GoToLivingRoom
                }
            },
            WorldItems = new List<WorldItem>
            {
                new()
                {
                    Id = 3,
                    Position = new Vector3(2,0,0),
                    ItemType = ItemType.CatFood,
                    Collected = false
                },
                new()
                {
                    Id = 4,
                    Position = new Vector3(0,1.6f,0),
                    ItemType = ItemType.Knife,
                    Collected = false
                }
            }
        };
        
        public SceneRoom LivingRoom = new()
        {
            SceneName = "LivingRoom",
            BackgroundValue = 3,
            ExistingDoors = new List<Door>
            {
                new()
                {
                    DoorName = "LivingRoomToKitchenDoor",
                    Position = new Vector3(-8.38f, -1.15f, 0),
                    EnteredRoomPosition = new Vector3(6.38f, -1.15f, 0),
                    GoToRoom = SceneLoader.GoToKitchen
                }
            },
            WorldItems = new List<WorldItem>
            {
                new()
                {
                    Id = 5,
                    Position = new Vector3(-4,0,0),
                    ItemType = ItemType.PaperTrash,
                    Collected = false
                }
            }
        };
        
        public SceneRoom Garden = new()
        {
            SceneName = "Garden",
            BackgroundValue = 4,
            ExistingDoors = new List<Door>
            {
                new()
                {
                    DoorName = "GardenToKitchenDoor",
                    Position = new Vector3(-0.13f, 4.7f, 0),
                    EnteredRoomPosition = new Vector3(-0.13f, -1.25f, 0),
                    GoToRoom = SceneLoader.GoToKitchen
                }
            },
            WorldItems = new List<WorldItem>
            {
                new()
                {
                    Id = 6,
                    Position = new Vector3(-4,1,0),
                    ItemType = ItemType.Apple,
                    Collected = false
                }
            }
        };
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public List<SceneRoom> AllSceneRooms()
        {
            return new List<SceneRoom>
            {
                StartScene,
                StevesRoom,
                Kitchen,
                LivingRoom,
                Garden
            };
        }
    }
}