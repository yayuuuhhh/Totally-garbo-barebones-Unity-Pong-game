using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * creds: Jeffrey Zhang, CS 383, 1/18/25
 */

public class EscapeMenuActivator : MonoBehaviour
{
    public Button escape;
    public Button restart;
    public Button help; // New Help button
    public GameObject helpTextUI; // UI element to display the help text
    public bool EscapeMenuOpen = false;

    void Start()
    {
        // Assign OnClick listeners programmatically
        if (help != null)
        {
            help.onClick.AddListener(ShowHelp); // Assign the ShowHelp method to the Help button
        }
        if (escape != null)
        {
            escape.onClick.AddListener(Escape); // Assign the Escape method to the Escape button
        }
        if (restart != null)
        {
            restart.onClick.AddListener(RestartLevel); // Assign the RestartLevel method to the Restart button
        }

        // Ensure all UI elements are hidden at the start
        if (helpTextUI != null)
        {
            helpTextUI.SetActive(false);
        }
        escape.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        help.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!EscapeMenuOpen)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        EscapeMenuOpen = true;
        Time.timeScale = 0f; // Pause the game
        escape.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        help.gameObject.SetActive(true); // Show the Help button
    }

    void ResumeGame()
    {
        EscapeMenuOpen = false;
        Time.timeScale = 1f; // Resume the game
        escape.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        help.gameObject.SetActive(false); // Hide the Help button
        if (helpTextUI != null)
        {
            helpTextUI.SetActive(false); // Hide the Help text
        }
    }

    public void Escape()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Ensure game time resumes when restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowHelp()
    {
        if (helpTextUI != null)
        {
            helpTextUI.SetActive(!helpTextUI.activeSelf); // Toggle the Help text visibility
        }
    }
}
