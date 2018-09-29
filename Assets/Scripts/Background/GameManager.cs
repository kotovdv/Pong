using Enums;
using UnityEngine;

namespace Background
{
    [RequireComponent(typeof(ScoreManager))]
    [RequireComponent(typeof(SpawnManager))]
    public class GameManager : MonoBehaviour, IPlayerScoredHandler
    {
        private ScoreManager _scoreManager;
        private SpawnManager _spawnManager;

        private void Awake()
        {
            _scoreManager = GetComponent<ScoreManager>();
            _spawnManager = GetComponent<SpawnManager>();
        }

        public void OnPlayerScored(Player scorer)
        {
            _scoreManager.OnPlayerScored(scorer);
            _spawnManager.OnPlayerScored(scorer);
        }
    }
}