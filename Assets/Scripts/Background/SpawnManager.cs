using System.Collections;
using Enums;
using UnityEngine;
using UnityEngine.Assertions;
using Random = System.Random;

namespace Background
{
    public class SpawnManager : MonoBehaviour, IPlayerScoredHandler
    {
        private static readonly Random Random = new Random();

        private readonly float[] _spawnAngles =
        {
            0f, 45f, 135f, 180f, 225f, 315f
        };

        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private Vector2[] _spawnPoints;


        private Ball _currentBall;

        private void Awake()
        {
            Assert.IsNotNull(_ballPrefab, "Ball prefab must be populated");
            Assert.IsNotNull(_spawnPoints, "Spawn points must be populated");
            Assert.IsFalse(_spawnPoints.Length == 0, "At least one spawn point must be specified");
        }

        private void Start()
        {
            InstantiateBall();
        }

        public void OnPlayerScored(Player scorer)
        {
            Destroy(_currentBall.gameObject);
            StartCoroutine(DelayedBallInstantiation(1.5f));
        }

        private void InstantiateBall()
        {
            var index = Random.Next(_spawnPoints.Length);
            var spawnPoint = _spawnPoints[index];

            var ballGameObject = Instantiate(_ballPrefab, spawnPoint, Quaternion.identity);
            var ball = ballGameObject.GetComponent<Ball>();

            ball.AssignMovementAngle(_spawnAngles[Random.Next(_spawnAngles.Length)]);
            _currentBall = ball;
        }


        private IEnumerator DelayedBallInstantiation(float delaySeconds)
        {
            yield return new WaitForSeconds(delaySeconds);
            InstantiateBall();
        }
    }
}