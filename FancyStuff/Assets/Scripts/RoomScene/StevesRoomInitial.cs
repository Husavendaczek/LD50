using UnityEngine;

namespace RoomScene
{
    public class StevesRoomInitial : MonoBehaviour
    {
        private void Start()
        {
            var mediator = FindObjectOfType<WorldMediator>();
            mediator.ShouldMove(true);
            mediator.InitCurrentScene();
        }
    }
}