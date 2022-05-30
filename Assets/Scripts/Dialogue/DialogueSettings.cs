using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;
    public List<Dialogue> dialogues = new List<Dialogue>();
}

[System.Serializable]
public class Dialogue
{
    public string actorName;
    public Sprite profile;
    public Languages languages;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
         DialogueSettings dialogueSettings = (DialogueSettings)target;
         Languages language = new Languages();
         Dialogue dialogue = new Dialogue();

         language.portuguese = dialogueSettings.sentence;
         dialogue.profile = dialogueSettings.speakerSprite;
         dialogue.languages = language;
         
         if(GUILayout.Button("Create Dialogue"))
         {
             if(dialogueSettings.sentence != "") {
                    dialogueSettings.dialogues.Add(dialogue);
                    // dialogueSettings.speakerSprite = null;
                    dialogueSettings.sentence = "";
             }
         }
    }
}
#endif