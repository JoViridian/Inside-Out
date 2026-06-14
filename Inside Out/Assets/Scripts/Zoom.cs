using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    public Camera cam;
    public GameObject lens;
    public AudioClip clip;
    private float lensScale;

    private void Start()
    {
        //lensScale = 1.25f;
        GameManager.Instance.zoomedIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            cam.fieldOfView -= Time.deltaTime * 120;
            //lensScale += 0.00833f; 
        }
        else
        {
            cam.fieldOfView += Time.deltaTime * 120;
            //lensScale -= 0.00833f;
        }

        //Mathf.Clamp(lensScale, 1.25f, 1.5f);
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 60);
        //lens.transform.localScale = new Vector3(lensScale, lensScale, lensScale);

        if (cam.fieldOfView <= 33)
        {
            GameManager.Instance.zoomedIn = true;
        }
        else
        {
            GameManager.Instance.zoomedIn = false;
        }
    }

    public void ZoomClick()
    {
        GameManager.Instance.PlayClip(clip, 0.5f);
    }
}
