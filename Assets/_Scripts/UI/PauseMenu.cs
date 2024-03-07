using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private int mainMenuBuildIndex;
    public static bool gamePaused = false;

    [Header("Options Menu")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundFxSlider;

    private void Awake()
    {
        InitialiceSoundSliders();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gamePaused = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Reload()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuBuildIndex);
    }

    private void InitialiceSoundSliders()
    {
        musicSlider.maxValue = 1f;
        soundFxSlider.maxValue = 1f;

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        soundFxSlider.value = PlayerPrefs.GetFloat("SoundFxVolume", 0.5f);
    }
}
