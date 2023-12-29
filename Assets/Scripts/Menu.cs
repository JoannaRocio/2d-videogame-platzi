using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        ResumeGame();
        SceneManager.LoadScene("SampleScene");
    }

    public void PauseGame()
    {
        gameManager.TogglePauseGame();
    }

    public void ResumeGame()
    {
        gameObject.SetActive(true);
    }

    public void OpenOptions()
    {
        // Implementa la lógica para abrir las opciones del menú
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
