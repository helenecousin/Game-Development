using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float currentScore = 0f;
    public bool isPlaying = false;

    private void Update() //increases score over time when playing
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }

        if (Input.GetKeyDown("k")) //temp game restart
        {
            isPlaying = true;
        }
    }

    public void GameOver() //resets score to 0 when game is over (player dies)
    {
        currentScore = 0;
        isPlaying = false;
    }

    public string PrettyScore () //rounds score to nearest integer and converts to a string
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

}
