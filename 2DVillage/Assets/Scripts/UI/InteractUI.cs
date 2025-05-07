using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class InteractUI : MonoBehaviour
    {
        [Header("Interaction")]
        [SerializeField] private GameObject interactPrompt;
        [SerializeField] private KeyCode interactKey;
        [SerializeField] private UnityEvent onInteract;
    
        private bool isPlayerInRange = false;

        private void Start()
        {
            interactPrompt.SetActive(false);
        }

        private void Update()
        {
            if (isPlayerInRange && Input.GetKeyDown(interactKey))
            {
                onInteract?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactPrompt.SetActive(true);
                isPlayerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactPrompt.SetActive(false);
                isPlayerInRange = false;
            }
        }
    }
}

