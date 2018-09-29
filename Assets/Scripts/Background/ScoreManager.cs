using System.Collections.Generic;
using Enums;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Background
{
    public class ScoreManager : MonoBehaviour, IPlayerScoredHandler
    {
        [SerializeField] private int _maxScore = 10;
        [SerializeField] private Text _firstPlayerScore;
        [SerializeField] private Text _secondPlayerScore;

        private readonly Dictionary<Player, int> _scores = new Dictionary<Player, int>();
        private readonly Dictionary<Player, Text> _scoresBoards = new Dictionary<Player, Text>();

        private void Awake()
        {
            ResetScores();
            _scoresBoards[Player.Left] = _firstPlayerScore;
            _scoresBoards[Player.Right] = _secondPlayerScore;
        }

        public void OnPlayerScored(Player scorer)
        {
            var newScore = _scores[scorer] + 1;
            if (newScore >= _maxScore)
            {
                ResetScores();
                ResetScoreBoard();
            }
            else
            {
                _scores[scorer] = newScore;
                _scoresBoards[scorer].text = newScore.ToString();
            }
        }

        private void ResetScores()
        {
            _scores[Player.Left] = 0;
            _scores[Player.Right] = 0;
        }

        private void ResetScoreBoard()
        {
            _scoresBoards.ForEach((player, text) => text.text = "0");
        }
    }
}