using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{

    [System.Serializable]
    public enum idiomes { portuguese, english, spanish };

    public idiomes language;

    [Header("Components")]
    public GameObject dialogueWindow;
    public Image profileSprite;
    public TMP_Text dialogue;
    public Text actorName;

    [Header("Settings")]
    public float typingSpeed;
    public bool isOpen;
    private int index;

    private string[] sentences;

    public static DialogueControl instance;

    private void Awake()
    {
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
        dialogue.text = "";
        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence(sentences[index]));
        }
        else
        {
            index = 0;
            dialogueWindow.SetActive(false);
            sentences = null;
            isOpen = false;
        }
    }

    public void Speech(string[] dialogues)
    {
        if (!isOpen)
        {
            dialogueWindow.SetActive(true);
            sentences = dialogues;
            StartCoroutine(TypeSentence(sentences[index]));
            isOpen = true;
        }
    }
}
