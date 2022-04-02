using RoomScene;
using UnityEngine;

namespace Interaction.Doors
{
    public class StevesRoomDoor : MonoBehaviour, IDoor
    {
        public void GoTo()
        {
            var sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.GoToKitchen();
        }
        
        private void OnMouseOver()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(200,200,200, 255);
        }

        private void OnMouseExit()
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}