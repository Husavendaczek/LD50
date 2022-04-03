using UnityEngine;

namespace RoomScene
{
    public class StevesRoomInitial : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("should only be called once");
            var mediator = FindObjectOfType<WorldMediator>();
            mediator.ShouldMove(true);
            mediator.InitCurrentScene();
        }
    }
}