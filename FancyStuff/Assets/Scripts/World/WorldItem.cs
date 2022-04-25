using Inventory;
using ItemProperty;
using UnityEngine;

namespace World
{
    public class WorldItem
    {
        public int Id;
        public ItemType ItemType;
        public Vector3 Position;
        public Vector3 ScaleSize;
        public bool Collected;
    }
}