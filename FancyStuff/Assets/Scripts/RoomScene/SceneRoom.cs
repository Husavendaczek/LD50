using System.Collections.Generic;
using Interaction;
using Interaction.Doors;
using World;

namespace RoomScene
{
    public class SceneRoom
    {
        public string SceneName;
        public List<WorldItem> WorldItems;
        public List<Door> ExistingDoors;
        public List<InteractableObj> InteractableObjs;
        public int BackgroundValue;
    }
}