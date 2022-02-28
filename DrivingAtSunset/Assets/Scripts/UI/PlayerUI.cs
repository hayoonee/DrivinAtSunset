using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerUI : MonoBehaviour
{
    /// <summary>
    /// This script handles the player ui and the scoring system
    /// </summary>

    [SerializeField] private PlayerCharacter _playerCharacter;
    [SerializeField] private TMP_Text _playerScoreTMP;

    private int playerScore = 0;
    

    private void Start()
    {
        //subscribe to the events
        _playerCharacter.CollectCoin += ChangeScore;
        _playerCharacter.CollectObstacle += ChangeScoreNegative;
    }

    private void ChangeScore()
    {
        playerScore += 30;
    }

    private void ChangeScoreNegative()
    {
        playerScore -= 100;
    }

    private void Update()
    {
        //Update the score, if the score goes below 0 -> just keep score 0
        if (playerScore > 0)
        {
            _playerScoreTMP.text = $"Score: {playerScore}";
        }
        else
        {
            playerScore = 0;
            _playerScoreTMP.text = $"Score: {playerScore}";
        }
    }
}
