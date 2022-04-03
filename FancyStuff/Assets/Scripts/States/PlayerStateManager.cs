using UnityEngine;

namespace States
{
    public class PlayerStateManager : MonoBehaviour
    {
        public GameObject player;
        public PlayerState currentState = PlayerState.Idle;
        
        public void StartWalkingAnimation()
        {
            currentState = PlayerState.Walking;
            SetPlayerAnimation("Walking", true);
        }

        public void StartInteraction()
        {
            currentState = PlayerState.Interacting;
            SetPlayerAnimation("Interacting", true);
        }

        public void Reset()
        {
            currentState = PlayerState.Idle;
            
            SetPlayerAnimation("Walking", false);
            SetPlayerAnimation("Interacting", false);
            SetPlayerAnimation("Taking", false);
            SetPlayerAnimation("Dropping", false);
        }

        public void Take()
        {
            currentState = PlayerState.Taking;
            SetPlayerAnimation("Taking", true);
        }

        public void Drop()
        {
            currentState = PlayerState.Dropping;
            SetPlayerAnimation("Dropping", true);
        }

        private void SetPlayerAnimation(string animationName, bool animated)
        {
            //TODO animate
            var animator = player.GetComponent<Animator>();
            animator.SetBool(animationName, animated);
        }
    }
}