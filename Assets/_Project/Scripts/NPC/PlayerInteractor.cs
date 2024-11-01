using FPSController;
using UnityEngine;
using UnityEngine.Events;

namespace FPSPlayground
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private FPSInputReader _inputReader;
        [SerializeField] private UnityEvent onInteract;

        private Interactable _currentInteractable;

        private void Start()
        {
            _inputReader.Interact += OnInteract;
        }

        private void OnTriggerEnter(Collider other)
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable == null)
                return;

            if (_currentInteractable != null)
                _currentInteractable.OnCanInteractExit.Invoke();

            _currentInteractable = interactable;
            interactable.OnCanInteractEnter.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable == null)
                return;

            if (_currentInteractable == interactable)
            {
                _currentInteractable = null;
                interactable.OnCanInteractExit.Invoke();
            }
        }

        private void OnInteract(bool b)
        {
            if (b && _currentInteractable != null)
            {
                _currentInteractable.OnInteract();
                onInteract.Invoke();
            }
        }

    }
}
