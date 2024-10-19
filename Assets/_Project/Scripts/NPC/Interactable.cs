using UnityEngine;
using UnityEngine.Events;

namespace FPSPlayground
{
    public class Interactable : MonoBehaviour
    {
        #region Fields
        [Header("Interactable")]
        [SerializeField] private Collider interactableCollider;

        [SerializeField] private UnityEvent onInteract;

        [SerializeField] private UnityEvent onCanInteractEnter;
        [SerializeField] private UnityEvent onCanInteractExit;

        internal UnityEvent OnCanInteractEnter => onCanInteractEnter;
        internal UnityEvent OnCanInteractExit => onCanInteractExit;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            if (interactableCollider == null)
                Debug.LogError("Interactable Collider is not set in " + gameObject.name);

            interactableCollider.isTrigger = true;
        }

        #endregion

        internal void OnInteract()
        {
            onInteract.Invoke();
        }

        public void DebugPrint()
        {
            Debug.Log("Piou piouuuuw");
        }
    }
}
