using UnityEngine;
using UnityEngine.Rendering;

public class CamSys : MonoBehaviour
{
    public float sensitivity = 30.0f;
    public float allowMove = 60.0f;
    public float minMove = -125;
    public float maxMove = -25;
    private float rotateX;
    private float rotateY;

    private void Start()
    {
        // Doesn't work - make more comments for yourself
        rotateX = transform.rotation.x;
        rotateY = transform.rotation.y;
    }

    void Update()
    {
        if (Input.mousePosition.x < allowMove)
        {   
            float buffer = - 2 * RotatedOverTop() * (Input.mousePosition.x - allowMove) / allowMove;
            rotateY -= sensitivity * Time.deltaTime * buffer;
            Debug.Log(RotatedOverTop());
        }

        if (Input.mousePosition.x > Screen.width - allowMove)
        {
            float buffer = 2 * RotatedOverTop() * (Input.mousePosition.x - Screen.width + allowMove) / allowMove;
            rotateY += sensitivity * Time.deltaTime * buffer;
            Debug.Log(RotatedOverTop());
        }

        if (Input.mousePosition.y < allowMove)
        {
            float buffer = - 2 * (Input.mousePosition.y - allowMove) / allowMove;
            rotateX = Mathf.Clamp(rotateX += sensitivity * Time.deltaTime * buffer, minMove, maxMove);
        }

        if (Input.mousePosition.y > Screen.height - allowMove)
        {
            float buffer = 2 * (Input.mousePosition.y - Screen.height + allowMove) / allowMove;
            rotateX = Mathf.Clamp(rotateX -= sensitivity * Time.deltaTime * buffer, minMove, maxMove);
        }

        transform.localEulerAngles = new Vector3(rotateX, rotateY, 0);
    }

    private float RotatedOverTop()
    {
        float a;
        if (rotateX <= -90)
        {
            a = -1;
        }
        else
        {
            a = 1;
        }
        return a;
    }
}
