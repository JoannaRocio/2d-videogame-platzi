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

    // Método para pausar o reanudar el juego
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

    // Método para pausar la lógica del juego
    private void PauseGame()
    {
        Time.timeScale = 0; // Detiene el tiempo
        // Aquí puedes agregar lógica adicional para pausar la lógica del juego
    }

    // Método para reanudar la lógica del juego
    public void ResumeGame()
    {
        Time.timeScale = 1; // Reanuda el tiempo
        // Aquí puedes agregar lógica adicional para reanudar la lógica del juego
    }
}
