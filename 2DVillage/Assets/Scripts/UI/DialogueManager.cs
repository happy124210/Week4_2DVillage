using UnityEngine;

namespace UI
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField] private DialogueUI dialogueUI;

        private Data.NPCDialogueData currentData;
        private int currentIndex;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void StartDialogue(Data.NPCDialogueData data)
        {
            currentData = data;
            currentIndex = 0;
            ShowCurrentLine();
        }

        public void NextLine()
        {
            currentIndex++;
            if (currentIndex >= currentData.dialogueLines.Count)
            {
                EndDialogue();
            }
            else
            {
                ShowCurrentLine();
            }
        }

        private void ShowCurrentLine()
        {
            string line = currentData.dialogueLines[currentIndex];
            dialogueUI.ShowDialogueUI(currentData.npcName, line, currentData.portrait);
        }

        public void EndDialogue()
        {
            dialogueUI.HideDialogueUI();
            currentData = null;
        }

        public bool IsDialogueActive => dialogueUI.gameObject.activeSelf;
    }
}
