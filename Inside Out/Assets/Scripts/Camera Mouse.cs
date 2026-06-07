using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    public float sensitivity = 1;
    public float clampAngleTop;
    public float clampAngleBot;
    public float clampAngleLeft;
    public float clampAngleRight;
    private float rotationX;
    private float rotationY;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.camLock)
        {
            DoCamMove();
        }
    }

    void DoCamMove()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        rotationY += mouseX * sensitivity * Time.deltaTime;
        rotationX -= mouseY * sensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, clampAngleTop, clampAngleBot);
        rotationY = Mathf.Clamp(rotationY, clampAngleLeft, clampAngleRight);

        if (transform.parent != null)
        {
            //Debug.Log("quater" + Quaternion.Euler(transform.parent.rotation.x, transform.rotation.y, transform.parent.rotation.z));
            transform.parent.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
            //Debug.Log(transform.parent.rotation);
            transform.rotation = Quaternion.Euler(rotationX, 0, 0);
            //Debug.Log(transform.rotation);
            transform.parent.rotation = Quaternion.Euler(0, rotationY, 0);
            //Debug.Log(transform.parent.rotation);
        }
        else 
        {
            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }
}
