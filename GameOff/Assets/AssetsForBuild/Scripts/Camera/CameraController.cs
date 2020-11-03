using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        if (!useOffsetValues)
        {
            offset = target.position - this.transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.SetParent(null);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        pivot.transform.position = target.transform.position;

        //Get the X position of the mouse & rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        //Get the Y position of the mouse & rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //Limit up/dowm camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            Quaternion newRotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
            pivot.rotation = Quaternion.Slerp(pivot.rotation, newRotation, 10 * Time.deltaTime);
        }


        //Move the camera based on the current rotation of the target & the original offset
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        this.transform.position = target.position - (rotation * offset);

        if (this.transform.position.y < target.position.y)
        {
            this.transform.position = new Vector3(transform.position.x, target.position.y, this.transform.position.z);
        }

        transform.LookAt(target);
    }
}
