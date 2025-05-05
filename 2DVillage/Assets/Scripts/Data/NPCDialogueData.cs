using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "NewNPCDialogue", menuName = "Dialogue/NPC Dialogue")]
    public class NPCDialogueData : ScriptableObject
    {
        public string npcId;
        public string npcName;
        public Sprite portrait;

        [TextArea]
        public List<string> dialogueLines;
    }
}
