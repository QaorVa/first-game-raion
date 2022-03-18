using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    // getter agar tidak bisa teroverride
    public string[] Dialogue => dialogue;
}
