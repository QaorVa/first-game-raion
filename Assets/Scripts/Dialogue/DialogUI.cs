using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObject testDialogue;
    private string sceneName;

    private TypeWriter typeWriter;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        typeWriter = GetComponent<TypeWriter>();
        if (!sceneName.Equals("Narration"))
        {
            CloseDialogBox();
        }
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogObject dialogObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        foreach(string dialogue in dialogObject.Dialogue)
        {
            yield return typeWriter.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (sceneName.Equals("Narration")) 
        {
            End();
        }

        CloseDialogBox();
        
    }

    private void CloseDialogBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;

    }

    private void End()
    {
        SceneManager.LoadSceneAsync("Bathroom");
    }
}
