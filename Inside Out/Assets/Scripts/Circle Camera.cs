using UnityEngine;

public class CircleCamera : MonoBehaviour
{
    public float sensitivity = 500;
    public float clampRadius;
    private float rotationX;
    private float rotationY;
    private Vector2 camPos;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.camLock)
        {
            DoCamMoveCircle();
        }
    }

    void DoCamMoveCircle()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        rotationY += mouseX * sensitivity * Time.deltaTime;
        rotationX -= mouseY * sensitivity * Time.deltaTime;
        camPos = new Vector2 (rotationX, rotationY);

        camPos = Vector2.ClampMagnitude(camPos, clampRadius);
        rotationX = camPos.x;
        rotationY = camPos.y;

        //rotationX = Mathf.Clamp(rotationX, -camPos.x, camPos.x);
        //rotationY = Mathf.Clamp(camPos.y, -camPos.y, camPos.y);
        Debug.Log(camPos);


        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
