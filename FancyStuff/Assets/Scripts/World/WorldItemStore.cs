using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace World
{
    public class WorldItemStore
    {
        public List<WorldItem> stevesRoomWorldItems = new List<WorldItem>
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
        };
        
        public List<WorldItem> kitchenWorldItems = new List<WorldItem>
        {
            new WorldItem
            {
                Id = 2,
                Position = new Vector3(0,0,0),
                ItemType = ItemType.CatFood,
                Collected = false
            }
        };
    }
}