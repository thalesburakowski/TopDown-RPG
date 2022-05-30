using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{

    [Header("Components")]
    public GameObject dialogueWindow;
    public Image profileSprite;
    public TMP_Text dialogue;
    public Text actorName;

    [Header("Settings")]
    public float typingSpeed;
    private bool isOpen;
    private int index;

    public static DialogueControl instance;

    private void Awake() {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

    }

    public void Speech(string[] text)
    {
        if (!isOpen)
        {
            dialogueWindow.SetActive(true);
            StartCoroutine(TypeSentence(text[index]));
            isOpen = true;
        }
        else
        {
            dialogueWindow.SetActive(false);
            isOpen = false;
        }
    }
}
