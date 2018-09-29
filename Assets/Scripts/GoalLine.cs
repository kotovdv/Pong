using Background;
using Enums;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    [SerializeField] private Player _scorer;
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            _gameManager.OnPlayerScored(_scorer);
        }
    }
}