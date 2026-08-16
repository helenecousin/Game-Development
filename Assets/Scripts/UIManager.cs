using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler()
    {
        startMenuUI.SetActive(false);
        gm.StartGame();
    }

    public void RestartButtonHandler()
    {
        gm.RestartGame();
    }

    public void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
