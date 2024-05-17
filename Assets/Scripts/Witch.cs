using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : NPC, ITalkable
{
    [SerializeField] private Dialogue dialogueText;
    [SerializeField] private DialogueController dialogueController;
    public override void Interact()
    {
        Talk(dialogueText);
    }

    public void Talk(Dialogue dialogueText)
    {
        dialogueController.DisplayNextParagraph(dialogueText);
    }
}
