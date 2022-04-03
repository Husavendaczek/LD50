using UnityEngine;
using World;

namespace Interaction.Doors
{
    public class DoorManager : MonoBehaviour
    {
        public WorldItemsOfSceneLoader worldItemsOfSceneLoader;
        public DoorCreator doorCreator;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void InitDoors()
        {
            Debug.Log("init the doors");
            var doors = worldItemsOfSceneLoader.DoorsForCurrentScene();

            foreach (var door in doors)
            {
                doorCreator.Create(door, transform);
            }
        }
    }
}