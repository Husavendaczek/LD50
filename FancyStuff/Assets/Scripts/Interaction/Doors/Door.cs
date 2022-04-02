using System;
using UnityEngine;

namespace Interaction.Doors
{
    public class Door
    {
        public string DoorName;
        public Action GoToRoom;
        public Vector3 Position;
        public Vector3 EnteredRoomPosition;

        public void GoTo()
        {
            GoToRoom();
        }
    }
}