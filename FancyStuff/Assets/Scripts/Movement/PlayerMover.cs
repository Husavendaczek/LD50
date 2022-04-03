using Helper;
using Interaction;
using Interaction.Doors;
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
        private GameObject _door;

        private bool _shouldMove = false;

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
                playerStateManager.Reset();

                if (_door != null)
                {
                    Debug.Log("door is" + _door);
                    var doorItem = _door.GetComponent<DoorMono>();
                    Mediator.SceneSwitchFromDoor(doorItem);
                    return;
                }
                
                if (_worldItem == null) return;
                Debug.Log("world item is" + _worldItem);
                var item = _worldItem.GetComponent<WorldItemMono>();
                Mediator.CollectItem(item);
                _worldItem = null;
            }
        }

        public void ShouldMove(bool move)
        {
            _shouldMove = move;

            if (!move)
            {
                playerStateManager.Reset();
                return;
            }

            _target = player.transform.position;
            _worldItem = null;
            _door = null;
        }

        private void CheckForCollisionWithWorldItem()
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CheckForCollisionWith(worldPosition);
        }

        private void CheckForCollisionWith(Vector3 worldPosition)
        {
            Collider2D overlapPoint = Physics2D.OverlapPoint(worldPosition);
            playerStateManager.StartWalkingAnimation();

            if (overlapPoint != null)
            {
                var collidedItem = overlapPoint.gameObject;

                if (collidedItem.GetComponent<IInteractable>() != null)
                {
                    _target = player.transform.position;
                    return;
                }
                
                _target = collidedItem.transform.position;
                if (collidedItem.GetComponent<WorldItemMono>() != null)
                {
                    _door = null;
                    _worldItem = collidedItem;
                }

                if (collidedItem.GetComponent<DoorMono>() != null)
                {
                    _worldItem = null;
                    _door = collidedItem;
                }
            }
            else
            {
                _target = worldPosition;
                _worldItem = null;
                _door = null;
            }
        }

        public void ResetPlayerPosition(Vector3 position)
        {
            _door = null;
            player.transform.position = position;
        }
    }
}