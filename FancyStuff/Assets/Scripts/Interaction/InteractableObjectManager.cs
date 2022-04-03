using System;
using UnityEngine;
using World;

namespace Interaction
{
    public class InteractableObjectManager : MonoBehaviour
    {
        public WorldItemsOfSceneLoader worldItemsOfSceneLoader;
        
        public GameObject interactablePrefab;
        public Sprite[] sprites;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void InitInteractables()
        {
            var interactables = worldItemsOfSceneLoader.InteractablesForCurrentScene();

            foreach (var interactable in interactables)
            {
                Create(interactable, transform);
            }
        }

        private void Create(InteractableObj interactable, Transform parentTransform)
        {
            var tmp = GameObject.Find(interactable.InteractableObjType.ToString());
            if(tmp != null) return;

            var interactableObject = Instantiate(interactablePrefab, parentTransform, true);
            interactableObject.name = interactable.InteractableObjType.ToString();
            interactableObject.transform.position = interactable.Position;
            interactableObject.tag = "Interactable";

            interactableObject.GetComponent<InteractableMono>().interactableObjType = interactable.InteractableObjType;
            interactableObject.GetComponent<SpriteRenderer>().sprite = sprites[(int) interactable.InteractableObjType];

            switch (interactable.InteractableObjType)
            {
                case InteractableObjType.Cat:
                    interactableObject.AddComponent<Cat>();
                    break;
                case InteractableObjType.Closet:
                    interactableObject.AddComponent<Closet>();
                    break;
                case InteractableObjType.Trash:
                    interactableObject.AddComponent<TrashCollector>();
                    break;
                case InteractableObjType.Grandma:
                    interactableObject.AddComponent<Grandma>();
                    break;
            }
        }
    }
}