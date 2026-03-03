using UnityEngine;
using TMPro;
using System.Collections;

public class ClipGuide : MonoBehaviour
{
    public TextMeshProUGUI speechText;
    public GameObject bubbleObject;

    public void ShowMessage(string message, float duration = 3f)
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(message, duration));
    }

    IEnumerator TypeSentence(string sentence, float duration)
    {
        bubbleObject.SetActive(true);

        if (WindowManager.Instance != null)
        {
            WindowManager.Instance.FocusWindow(bubbleObject);
        }

        speechText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(duration);
        bubbleObject.SetActive(false);
    }
}