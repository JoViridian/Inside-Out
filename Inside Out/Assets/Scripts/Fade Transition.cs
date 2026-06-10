using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    public float fadeTimer;
    private float fadeTimerInt;
    public Image image;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeTimerInt = fadeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.allowInteract)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Abs(Mathf.Abs(1 - 2 * fadeTimerInt) - 1));
            fadeTimerInt -= Time.deltaTime;
        }
        else
        {
            fadeTimerInt = fadeTimer;
        }
    }
}
