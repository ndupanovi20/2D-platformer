using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameOverManager : MonoBehaviour
{
    public GameObject winCanvas;

    void Start()
    {
        winCanvas.SetActive(false); 
    }

    public void ShowWinScreen()
    {
        winCanvas.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
