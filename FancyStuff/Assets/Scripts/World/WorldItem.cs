using Inventory;
using UnityEngine;

namespace World
{
    public class WorldItem
    {
        public int Id;
        public ItemType ItemType;
        public Vector3 Position;
        public bool Collected;
    }
}