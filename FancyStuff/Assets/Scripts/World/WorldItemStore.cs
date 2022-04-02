using System.Collections.Generic;
using Inventory;
using RoomScene;
using UnityEngine;

namespace World
{
    public class WorldItemStore : MonoBehaviour
    {
        public Sprite[] backgrounds;
        public SceneRoom StartScene = new SceneRoom
        {
            SceneName = "StartScene",
            BackgroundValue = 0,
            WorldItems = new List<WorldItem>()
        };
        
        public SceneRoom StevesRoom = new SceneRoom
        {
            SceneName = "StevesRoom",
            BackgroundValue = 1,
            WorldItems = new List<WorldItem>
            {
                new WorldItem
                {
                    Id = 0,
                    Position = new Vector3(0,0,0),
                    ItemType = ItemType.PaperTrash,
                    Collected = false
                },
                new WorldItem
                {
                    Id = 1,
                    Position = new Vector3(1,1,0),
                    ItemType = ItemType.PaperTrash,
                    Collected = false
                }
            }
        };
        
        public SceneRoom Kitchen = new SceneRoom
        {
            SceneName = "Kitchen",
            BackgroundValue = 2,
            WorldItems = new List<WorldItem>
            {
                new WorldItem
                {
                    Id = 2,
                    Position = new Vector3(0,0,0),
                    ItemType = ItemType.CatFood,
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
                Kitchen
            };
        }
    }
}