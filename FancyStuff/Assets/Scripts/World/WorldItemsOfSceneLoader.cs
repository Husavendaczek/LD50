using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class WorldItemsOfSceneLoader : MonoBehaviour
    {
        public List<WorldItem> WorldItemsForCurrentScene()
        {
            var currentScene = SceneManager.GetActiveScene().name;
            var worldItemStore = FindObjectOfType<WorldItemStore>();

            if (currentScene == worldItemStore.StevesRoom.SceneName)
            {
                return worldItemStore.StevesRoom.WorldItems.Where(worldItem => worldItem.Collected == false).ToList();
            }
            else if (currentScene == worldItemStore.Kitchen.SceneName)
            {
                return worldItemStore.Kitchen.WorldItems.Where(worldItem => worldItem.Collected == false).ToList();
            }

            return new List<WorldItem>();
        }
    }
}