using System;
using Person;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject enemies;
    private Transform[] _enemies;

    private void FixedUpdate()
    {
        // TODO it's a hack. fix it
        _enemies = enemies.GetComponentsInChildren<Transform>();
        Debug.Log(_enemies.Length);
        if (_enemies.Length == 1)
        {
            Win();
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Win()
    {
        winScreen.SetActive(true);
    }
}