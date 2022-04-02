using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class WorldItemManager : MonoBehaviour
    {
        private WorldItemCreator _worldItemCreator;

        private readonly List<WorldItemMono> _currentViewableWorldItems = new List<WorldItemMono>();
        private int maximumId = 0;



        private void Start()
        {
            var worldItemsOfSceneLoader = FindObjectOfType<WorldItemsOfSceneLoader>();
            var worldItemsForScene = worldItemsOfSceneLoader.WorldItemsForCurrentScene();

            foreach (var worldItem in worldItemsForScene)
            {
                if (worldItem.Id > maximumId)
                {
                    maximumId = worldItem.Id;
                }
                _currentViewableWorldItems.Add(_worldItemCreator.Create(worldItem));
            }
        }
    }
}