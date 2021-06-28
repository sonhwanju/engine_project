using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartSceneUI : MonoBehaviour
{
    public GameObject adPanel;
    public bool isOpen = false;

    public void GameScene() {
        
        SceneManager.LoadScene(1);
    }

    public void Advice() {
        adPanel.SetActive(true);
        isOpen = true;
    }
    public void Quit() {
        Application.Quit();
    }

    void Update()
    {
        if(isOpen && Input.GetKeyDown(KeyCode.Escape)) {
            adPanel.SetActive(false);
            isOpen = false;
        }
    }
}
