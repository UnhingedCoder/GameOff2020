using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform pivot;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
