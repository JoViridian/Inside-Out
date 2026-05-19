using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private float sensitivity = 30.0f;
    private float allowMove = 60.0f;
    private float rotateX;
    private float rotateY;


    void Update()
    {
        
        if (Input.mousePosition.x < allowMove)
        {   
            float buffer = - 2 * (Input.mousePosition.x - allowMove) / allowMove;
            rotateY -= sensitivity * Time.deltaTime * buffer;
        }

        if (Input.mousePosition.x > Screen.width - allowMove)
        {
            float buffer = 2 * (Input.mousePosition.x - Screen.width + allowMove) / allowMove;
            rotateY += sensitivity * Time.deltaTime * buffer;
        }

        if (Input.mousePosition.y < allowMove)
        {
            float buffer = - 2 * (Input.mousePosition.y - allowMove) / allowMove;
            rotateX = Mathf.Clamp(rotateX += sensitivity * Time.deltaTime * buffer, -125, -25);
        }

        if (Input.mousePosition.y > Screen.height - allowMove)
        {
            float buffer = 2 * (Input.mousePosition.y - Screen.height + allowMove) / allowMove;
            rotateX = Mathf.Clamp(rotateX -= sensitivity * Time.deltaTime * buffer, -125, -25);
        }

        transform.localEulerAngles = new Vector3(rotateX, rotateY, 0);
    }
}
