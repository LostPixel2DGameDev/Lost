using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed = 10;

    private Queue<string> paragraphs = new Queue<string>();
    private bool conversationEnded;
    private string p;

    private Coroutine typeDialogueCoroutine;
    private bool isTyping;

    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TYPE_TIME = 0.05f;

    public void DisplayNextParagraph(Dialogue dialogueText)
    {
        if (paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                StartConversation(dialogueText);
            }
            else
            {
                EndConversation();
                return;
            }
        }

        if (!isTyping)
        {
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
        }

        

        NPCDialogueText.text = p;

        if (paragraphs.Count == 0)
        {
            conversationEnded = true;
        }



    }

    private void StartConversation(Dialogue dialogueText)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        NPCNameText.text = dialogueText.speakerName;

        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }

    private void EndConversation()
    {
        conversationEnded = false;

        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    //private IEnumerator TypeDialogueText(string p)
    //{
    //    float elapsedTime = 0f;

    //    int charIndex = 0;
    //    charIndex = Mathf.Clamp(charIndex, 0, p.Length);

    //    while (charIndex < p.Length)
    //    {
    //        elapsedTime += Time.deltaTime + typeSpeed;
    //        charIndex = Mathf.FloorToInt(elapsedTime);
    //        NPCDialogueText.text = p.Substring(0, charIndex);

    //        yield return null;
    //    }

    //    NPCDialogueText.text = p;
    //}

    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;

        NPCDialogueText.text = "";

        string originalText = p;
        string displayText = "";

        int alphaIndex = 0;

        foreach (char c in p.ToCharArray())
        {
            alphaIndex++;
            NPCDialogueText.text = originalText;

            displayText = NPCDialogueText.text.Insert(alphaIndex, HTML_ALPHA);
            NPCDialogueText.text = displayText;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }
        NPCDialogueText.text = displayText;
        isTyping = false;
    }
}
