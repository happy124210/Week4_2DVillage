using UnityEngine;
using UnityEngine.SceneManagement;

namespace Portal
{
    public class PortalHandler : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad = "MiniGameScene";
        [SerializeField] private KeyCode interactKey = KeyCode.E;
    
        private bool isPlayerInRange;
    
        private void Update()
        {
            if (isPlayerInRange && Input.GetKeyDown(interactKey))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = false;
            }
        }
    }
}