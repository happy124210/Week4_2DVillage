using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Image portraitImage;

        private void Start()
        {
            HideDialogueUI();
        }

        public void ShowDialogueUI(string npcName, string dialogueLine, Sprite portrait)
        {
            gameObject.SetActive(true);
            nameText.text = npcName;
            dialogueText.text = dialogueLine;
            portraitImage.sprite = portrait;
        }

        public void HideDialogueUI()
        {
            gameObject.SetActive(false);
        }
    }
}
