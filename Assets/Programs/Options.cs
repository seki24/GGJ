using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject optionPanel = null;
    [SerializeField] GameObject pauseMenu = null;
    
    void Update()
    {
        Time.timeScale = 0;
        optionPanel.SetActive(true);
        // Input.GetKeyDown(KeyCode.Escape) = 0;
    }

    public void back()
    {
        Time.timeScale = 0;
        optionPanel.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
