using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class sceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public string indicatorBody;
    public GameObject indicator;
    public TMP_Text indicatorText;
    public bool isInRange;
    public Vector2 playerPos;
    public vectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait = .5f;

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
            indicatorText.text = indicatorBody;
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
