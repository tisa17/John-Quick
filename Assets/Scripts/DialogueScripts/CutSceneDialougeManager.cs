﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CutSceneDialougeManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    
    // Start is called before the first frame update

    private Queue<string> sentences;

    void Start()
    {

        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialog dialogue)
    {

        
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();


    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;

        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }
    IEnumerator TypeSentence(string sentence)
    {

        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        


    }


}
