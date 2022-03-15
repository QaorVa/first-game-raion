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
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            playerStorage.initialValue = playerPos;
            indicator.SetActive(false);
            StartCoroutine(FadeCoroutine());
            //SceneManager.LoadScene(sceneToLoad);
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

    public IEnumerator FadeCoroutine()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
