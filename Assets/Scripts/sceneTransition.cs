using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public GameObject indicator;
    public bool isInRange;
    public Vector2 playerPos;
    public vectorValue playerStorage;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            playerStorage.initialValue = playerPos;
            indicator.SetActive(false);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            indicator.SetActive(true);
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            indicator.SetActive(false);
            
        }
    }
}
