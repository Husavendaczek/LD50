using UnityEngine;

namespace Helper
{
    public static class VectorMapper
    {
        public static Vector2 ToVector2(Vector3 position3d)
        {
            return new Vector2(position3d.x, position3d.y);
        }
    
        public static Vector3 ToVector3(Vector2 position2d)
        {
            return new Vector3(position2d.x, position2d.y, 0);
        }
    }
}