using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30;
    public int difficulty = 1;

    private bool isGamePaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }   
    }

    private void Start()
    {
        //PauseGame();
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }

    // M�todo para pausar o reanudar el juego
    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    // M�todo para pausar la l�gica del juego
    private void PauseGame()
    {
        Time.timeScale = 0; // Detiene el tiempo
        // Aqu� puedes agregar l�gica adicional para pausar la l�gica del juego
    }

    // M�todo para reanudar la l�gica del juego
    public void ResumeGame()
    {
        Time.timeScale = 1; // Reanuda el tiempo
        // Aqu� puedes agregar l�gica adicional para reanudar la l�gica del juego
    }
}
