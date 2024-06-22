using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool hasKey = false;
    public GameOverManager gameOverManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndGame()
    {
        gameOverManager.ShowWinScreen();
    }
}
