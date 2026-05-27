using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera cam;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            cam.fieldOfView--;
        }
        else
        {
            cam.fieldOfView++;
        }
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 60);
    }
}
