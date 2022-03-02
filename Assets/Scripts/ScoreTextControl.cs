using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextControl : MonoBehaviour
{
    private Text text;

    [SerializeField]
    private IntVariable scorePlayer;
    [SerializeField]
    private IntVariable scoreEnemy;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        text.text = scorePlayer.Value + " : " + scoreEnemy.Value;
    }

    public void UpdateValueScore()
    {
        text.text = scorePlayer.Value + " : " + scoreEnemy.Value;
    }
}
