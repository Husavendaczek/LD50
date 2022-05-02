using System;
using UnityEngine;
using UnityEngine.Serialization;
using World;

namespace Interaction
{
    public class InteractableObjectManager : MonoBehaviour
    {
        public WorldItemsOfSceneLoader worldItemsOfSceneLoader;

        public GameObject interactablePrefab;
        public Sprite[] normalSprites;
        public Sprite[] positiveOutcomes;
        public Sprite[] negativeOutcomes;

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
            interactableObject.GetComponent<SpriteRenderer>().sprite = normalSprites[(int) interactable.InteractableObjType];
            
            //TODO set sprite according to interactable state

            switch (interactable.InteractableObjType)
            {
                case InteractableObjType.Cat:
                    interactableObject.AddComponent<Cat>();
                    var cat = interactableObject.GetComponent<Cat>();
                    cat.positiveOutcome = positiveOutcomes[(int) interactable.InteractableObjType];
                    cat.negativeOutcome = negativeOutcomes[(int) interactable.InteractableObjType];
                    break;
                case InteractableObjType.Closet:
                    interactableObject.AddComponent<Closet>();
                    var closet = interactableObject.GetComponent<Closet>();
                    closet.positiveOutcome = positiveOutcomes[(int) interactable.InteractableObjType];
                    closet.negativeOutcome = negativeOutcomes[(int) interactable.InteractableObjType];
                    break;
                case InteractableObjType.Trash:
                    interactableObject.AddComponent<TrashCollector>();
                    var trashCollector = interactableObject.GetComponent<TrashCollector>();
                    trashCollector.positiveOutcome = positiveOutcomes[(int) interactable.InteractableObjType];
                    trashCollector.negativeOutcome = negativeOutcomes[(int) interactable.InteractableObjType];
                    break;
                case InteractableObjType.Grandma:
                    interactableObject.AddComponent<Grandma>();
                    
                    var grandma = interactableObject.GetComponent<Grandma>();
                    grandma.positiveOutcome = positiveOutcomes[(int) interactable.InteractableObjType];
                    grandma.negativeOutcome = negativeOutcomes[(int) interactable.InteractableObjType];
                    break;
            }
        }
    }
}