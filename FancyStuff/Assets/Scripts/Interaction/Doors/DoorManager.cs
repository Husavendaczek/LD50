using System.Collections.Generic;
using UnityEngine;
using World;

namespace Interaction.Doors
{
    public class DoorManager : MonoBehaviour
    {
        public WorldItemsOfSceneLoader worldItemsOfSceneLoader;
        public DoorCreator doorCreator;
        
        private readonly List<DoorMono> _currentViewableDoors = new List<DoorMono>();
        private void Start()
        {
            InitDoors();
        }

        public void InitDoors()
        {
            ResetDoors();
            var doors = worldItemsOfSceneLoader.DoorsForCurrentScene();

            foreach (var door in doors)
            {
                var doorMono = doorCreator.Create(door, transform);
                _currentViewableDoors.Add(doorMono);
            }
        }

        private void ResetDoors()
        {
            foreach (var currentViewableDoor in _currentViewableDoors)
            {
                Destroy(currentViewableDoor.gameObject);
            }
        }
    }
}