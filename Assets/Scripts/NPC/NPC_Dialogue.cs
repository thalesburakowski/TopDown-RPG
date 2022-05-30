using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public bool nextToNpc;
    public DialogueSettings dialogue;

    private List<string> sentences = new List<string>();

    void Start()
    {
        GetNPCDialogues();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nextToNpc)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCDialogues()
    {
        for (var i = 0; i < dialogue.dialogues.Count; i++)
        {
            sentences.Add(dialogue.dialogues[i].languages.portuguese);
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D npcColider = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if (npcColider != null)
        {
            nextToNpc = true;
        }
        else
        {
            nextToNpc = false;
            DialogueControl.instance.dialogueWindow.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
