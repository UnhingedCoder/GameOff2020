using UnityEngine;
using UnityEngine.Events;

public class PlayerEventTransmitter : MonoBehaviour
{
    [HideInInspector] public UnityEvent e_Jump;
    [HideInInspector] public UnityEvent e_EnableMovement;
    [HideInInspector] public UnityEvent e_DisableMovement;

    void AddJumpForce()
    {
        e_Jump.Invoke();
    }

    void DisableMovement()
    {
        e_DisableMovement.Invoke();
    }

    void EnableMovement()
    {
        e_EnableMovement.Invoke();
    }
}
