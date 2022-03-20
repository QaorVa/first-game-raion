using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Interact : MonoBehaviour
{
    public Flowchart Flowchart;
    public string blockToLoad;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Body"))
        {
            Flowchart.gameObject.SetActive(true);
            Flowchart.ExecuteBlock(blockToLoad);
        }
    }
}
