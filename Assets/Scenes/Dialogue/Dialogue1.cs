using UnityEngine;
using UnityEngine.UI;
public class Dialogue1 : MonoBehaviour
{
    public string[] lines;
    public float TextSpeed;
    public Text dialogueText;
    private int index;
    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }
    IEnumerator TypeLine
    {
        foreach(char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSecond(TextSpeed);
        }
    }
    
    public void SkipTextClick();
    {
        if(dialogueText.text == lines[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }

    private void NextLines()
    {
        if(index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
