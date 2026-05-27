using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    public Camera cam;
    public GameObject lens;
    private float lensScale;

    private void Start()
    {
        //lensScale = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            cam.fieldOfView--;
            //lensScale += 0.00833f; 
        }
        else
        {
            cam.fieldOfView++;
            //lensScale -= 0.00833f;
        }

        //Mathf.Clamp(lensScale, 1.25f, 1.5f);
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 60);
        //lens.transform.localScale = new Vector3(lensScale, lensScale, lensScale);
    }
}
