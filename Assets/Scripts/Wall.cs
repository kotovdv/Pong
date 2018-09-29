using Enums;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private Direction _correspondingDirection;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            DisablePlayerDirectionMovement(col);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           EnablePlayerDirectionMovement(col);
        }
    }

    private void DisablePlayerDirectionMovement(Component component)
    {
        SetDirectionMovementState(component, _correspondingDirection, false);
    }

    private void EnablePlayerDirectionMovement(Component component)
    {
        SetDirectionMovementState(component, _correspondingDirection, true);
    }

    private static void SetDirectionMovementState(Component component, Direction direction, bool isAllowed)
    {
        var controller = component.GetComponent<PlayerController>();
        controller.SetMovementLockedState(direction, isAllowed);
    }
}