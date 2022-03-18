using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public string dialog;
    public string indicatorBody;
    public bool isInRange;
    public GameObject indicator;
    public TMP_Text indicatorText;
    public TMP_Text dialogTMP;
    public Image charSprite;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                indicator.SetActive(true);
                charSprite.gameObject.SetActive(false);
            } else
            {
                indicator.SetActive(false);
                dialogBox.SetActive(true);
                charSprite.gameObject.SetActive(true);
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
            indicatorText.text = indicatorBody;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
            dialogBox.SetActive(false);
            indicator.SetActive(false);
            charSprite.gameObject.SetActive(false);
        }
    }
}
