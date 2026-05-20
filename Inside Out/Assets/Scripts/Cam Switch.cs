using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject camGround;
    public GameObject camSky;

    // Update is called once per frame
    void Start()
    {
        GameManager.Instance.camState = false;
    }

    public void SwapCamera()
    {
        if (GameManager.Instance.camState)
        {
            camGround.SetActive(true);
            camSky.SetActive(false);
        }
        else
        {
            camGround.SetActive(false);
            camSky.SetActive(true);
        }

        GameManager.Instance.camState = !GameManager.Instance.camState;
    }
}
