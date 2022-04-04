using System.Collections.Generic;
using System.Linq;
using Interaction;
using Interaction.Doors;
using ItemProperty;
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
            InteractableObjs = new List<InteractableObj>(),
            WorldItems = new List<WorldItem>()
        };
        public SceneRoom SadEnd = new()
        {
            SceneName = "SadEnd",
            ExistingDoors = new List<Door>(),
            BackgroundValue = 0,
            InteractableObjs = new List<InteractableObj>(),
            WorldItems = new List<WorldItem>()
        };
        public SceneRoom HappyEnd = new()
        {
            SceneName = "HappyEnd",
            ExistingDoors = new List<Door>(),
            BackgroundValue = 0,
            InteractableObjs = new List<InteractableObj>(),
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
                    GoToRoom = SceneLoader.GoToKitchen,
                    SpriteValue = 1
                }
            },
            InteractableObjs = new List<InteractableObj>
            {
                new()
                {
                    InteractableObjType = InteractableObjType.Trash,
                    Position = new Vector3(3, -1.27f, 0)
                },
                new()
                {
                    InteractableObjType = InteractableObjType.Closet,
                    Position = new Vector3(-1.56f, -0.89f, 0)
                }
            },
            WorldItems = new List<WorldItem>
            {
                new()
                {
                    Id = 0,
                    Position = new Vector3(-3.34f,-3,0),
                    ItemType = ItemType.PaperTrash,
                    Collected = false
                },
                new()
                {
                    Id = 1,
                    Position = new Vector3(1.02f,-2.02f,0),
                    ItemType = ItemType.PaperTrash,
                    Collected = false
                },
                new()
                {
                    Id = 1,
                    Position = new Vector3(3.08f,-2.96f,0),
                    ItemType = ItemType.Clothes,
                    Collected = false
                },
                new()
                {
                    Id = 2,
                    Position = new Vector3(4.75f,-1.57f,0),
                    ItemType = ItemType.RottenBanana,
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
                    GoToRoom = SceneLoader.GoToStevesRoom,
                    SpriteValue = 0
                },
                new()
                {
                    DoorName = "KitchenToGardenDoor",
                    Position = new Vector3(-0.13f, -0.24f, 0),
                    EnteredRoomPosition = new Vector3(-0.13f, -0.24f, 0),
                    GoToRoom = SceneLoader.GoToGarden,
                    SpriteValue = 1
                },
                new()
                {
                    DoorName = "KitchenToLivingRoomDoor",
                    Position = new Vector3(8.38f, -1.15f, 0),
                    EnteredRoomPosition = new Vector3(-6.38f, -1.15f, 0),
                    GoToRoom = SceneLoader.GoToLivingRoom,
                    SpriteValue = 1
                }
            },
            InteractableObjs = new List<InteractableObj>
            {
                new()
                {
                    InteractableObjType = InteractableObjType.Cat,
                    Position = new Vector3(3, -1.75f, 0)
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
                    Position = new Vector3(-3.09f,-0.41f,0),
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
                    GoToRoom = SceneLoader.GoToKitchen,
                    SpriteValue = 2
                }
            },
            InteractableObjs = new List<InteractableObj>
            {
                new()
                {
                    InteractableObjType = InteractableObjType.Grandma,
                    Position = new Vector3(-0.65f, -1.15f, 0)
                }
            },
            WorldItems = new List<WorldItem>
            {
                new()
                {
                    Id = 5,
                    Position = new Vector3(7.33f,-3,0),
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
                    Position = new Vector3(8.24f, -0.73f, 0),
                    EnteredRoomPosition = new Vector3(-0.13f, -1.25f, 0),
                    GoToRoom = SceneLoader.GoToKitchen,
                    SpriteValue = 1
                }
            },
            InteractableObjs = new List<InteractableObj>(),
            WorldItems = new List<WorldItem>
            {
                new()
                {
                    Id = 6,
                    Position = new Vector3(-3.63f,-2.73f,0),
                    ItemType = ItemType.Apple,
                    Collected = false
                },
                new()
                {
                    Id = 7,
                    Position = new Vector3(3.87f,-3.15f,0),
                    ItemType = ItemType.Apple,
                    Collected = false
                },
                new()
                {
                    Id = 8,
                    Position = new Vector3(5.59f,-2.09f,0),
                    ItemType = ItemType.Apple,
                    Collected = false
                },
                new()
                {
                    Id = 9,
                    Position = new Vector3(-7.39f,-1.67f,0),
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

        public void DestroyOldDoors(SceneRoom scene)
        {
            if (scene == null)
            {
                return;
            }

            if (!scene.ExistingDoors.Any())
            {
                return;
            }

            var existingDoors = AllSceneRooms().FirstOrDefault(sceneRoom => sceneRoom.SceneName == scene.SceneName)!.ExistingDoors;

            var allViewableDoors = GameObject.FindGameObjectsWithTag("Door").ToList();

            foreach (var viewableDoor in allViewableDoors)
            {
                var currentDoor = viewableDoor.GetComponent<DoorMono>();

                var hasDoor = existingDoors.Where(door => door.DoorName == currentDoor.doorName);

                if (!hasDoor.Any())
                {
                    Destroy(viewableDoor.gameObject);
                }
            }
        }

        public void DestroyOldWorldItems(SceneRoom scene)
        {
            if (scene == null)
            {
                return;
            }

            if (!scene.WorldItems.Any())
            {
                return;
            }

            var existingWorldItems =
                AllSceneRooms().FirstOrDefault(sceneRoom => sceneRoom.SceneName == scene.SceneName)!.WorldItems;

            var allViewableWorldItems = GameObject.FindGameObjectsWithTag("WorldItem");

            foreach (var viewableWorldItem in allViewableWorldItems)
            {
                var currentWorldItem = viewableWorldItem.GetComponent<WorldItemMono>();

                var hasWorldItem = existingWorldItems.Where(item => item.Id == currentWorldItem.id);

                if (!hasWorldItem.Any())
                {
                    Destroy(viewableWorldItem.gameObject);
                }
            }
        }

        public void DestroyOldInteractables(SceneRoom scene)
        {
            if (scene == null)
            {
                return;
            }

            if (!scene.WorldItems.Any())
            {
                return;
            }

            var existingInteractables =
                AllSceneRooms().FirstOrDefault(sceneRoom => sceneRoom.SceneName == scene.SceneName)!.InteractableObjs;

            var allViewableInteractables = GameObject.FindGameObjectsWithTag("Interactable");

            foreach (var viewableInteractable in allViewableInteractables)
            {
                var currentInteractable = viewableInteractable.GetComponent<InteractableMono>();

                var hasWorldItem = existingInteractables.Where(obj => obj.InteractableObjType == currentInteractable.interactableObjType);

                if (!hasWorldItem.Any())
                {
                    Destroy(viewableInteractable.gameObject);
                }
            }
        }
    }
}