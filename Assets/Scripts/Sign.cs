using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public string dialog;
    public bool isInRange;
    public GameObject indicator;
    public TMP_Text dialogTMP;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                indicator.SetActive(true);
            } else
            {
                indicator.SetActive(false);
                dialogBox.SetActive(true);
                dialogTMP.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            indicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
            dialogBox.SetActive(false);
            indicator.SetActive(false);
        }
    }
}
