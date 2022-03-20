using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneTransition : MonoBehaviour
{
    public GameObject fadeOutPanel;

    private void Awake()
    {
        if (fadeOutPanel != null)
        {
            GameObject panel = Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
            
        }
    }
    
}
