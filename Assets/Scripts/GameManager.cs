using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] private GameObject Player;
    [SerializeField] private Transform PlayerSpawnPoint;

    //The score increases while the game is actively being played
    public float currentScore = 0f;

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();

    public UnityEvent onGameOver = new UnityEvent();

    private void Update() //increases score over time when playing
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        onPlay.Invoke();
        currentScore = 0f;
        isPlaying = true;

        //reset platform here

        //checks if a player already exists, preventing StartGame from creating multiple players
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            //creates a new player at the player starting position
            Instantiate(Player, PlayerSpawnPoint.position, Quaternion.identity);
        }
    }

    public void GameOver() //resets score to 0 when game is over (player dies)
    {
        onGameOver.Invoke();
        currentScore = 0;
        isPlaying = false;
    }

    public string PrettyScore () //rounds score to nearest integer and converts to a string
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

}
