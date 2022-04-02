using Helper;
using RoomScene;
using States;
using UnityEngine;
using World;

namespace Movement
{
    public class PlayerMover : MonoBehaviour
    {
        public IMediator Mediator;
        public PlayerStateManager playerStateManager;
        public GameObject player;
        
        private const float Speed = 2.0f;
        private Vector2 _target;

        private GameObject _worldItem;

        private bool _shouldMove = true;

        private void Update()
        {
            if (playerStateManager == null) return;
            
            if (Input.GetMouseButtonDown(0) && _shouldMove)
            {
                CheckForCollisionWithWorldItem();
            }

            if (playerStateManager.currentState != PlayerState.Walking) return;

            var step = Speed * Time.deltaTime;
            var position = player.transform.position;
            var charPos = VectorMapper.ToVector2(position);
            var direction = (_target - charPos).normalized;

            position += VectorMapper.ToVector3(direction) * step;
            player.transform.position = position;

            if (Mathf.Abs(player.transform.position.x - _target.x) <= 1f && Mathf.Abs(player.transform.position.y - _target.y) <= 1f)
            {
                Debug.Log("reached target");
                Debug.Log("world item is" + _worldItem);
                playerStateManager.Reset();
                
                if (_worldItem == null) return;
                var item = _worldItem.GetComponent<WorldItemMono>();
                Mediator.CollectItem(item);
            }
        }

        public void PauseMovement(bool pause)
        {
            _shouldMove = pause;
        }

        private void CheckForCollisionWithWorldItem()
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D overlapPoint = Physics2D.OverlapPoint(worldPosition);
            playerStateManager.StartWalkingAnimation();

            if (overlapPoint != null)
            {
                var collidedItem = overlapPoint.gameObject;
                //TODO clamp target
                _target = collidedItem.transform.position;
                if (collidedItem.GetComponent<WorldItemMono>() != null)
                {
                    _worldItem = collidedItem;
                }
            }
            else
            {
                //TODO clamp target
                _target = worldPosition;
                _worldItem = null;
            }
        }
    }
}