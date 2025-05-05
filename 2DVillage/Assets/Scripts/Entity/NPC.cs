using UnityEngine;

namespace Entity
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private Data.NPCDialogueData dialogueData;
        private bool isPlayerInRange;

        private void Update()
        {
            if (!isPlayerInRange) return;

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!UI.DialogueManager.Instance.IsDialogueActive)
                    UI.DialogueManager.Instance.StartDialogue(dialogueData);
                else
                {
                    UI.DialogueManager.Instance.NextLine();
                }
                    
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UI.DialogueManager.Instance.EndDialogue();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) isPlayerInRange = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player")) isPlayerInRange = false;
        }
    }
}
