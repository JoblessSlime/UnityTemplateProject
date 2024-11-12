using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text speakerNameText;
    public Text dialogueText;
    public GameObject dialoguePanel;
    
    private Dialogue currentDialogue;
    private int currentLineIndex;

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        currentLineIndex = 0;
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (currentLineIndex < currentDialogue.lines.Length)
        {
            DialogueLine line = currentDialogue.lines[currentLineIndex];
            speakerNameText.text = line.speakerName;
            dialogueText.text = line.dialogueText;
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        currentDialogue = null;
    }
}