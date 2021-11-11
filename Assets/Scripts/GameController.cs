using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}