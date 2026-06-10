using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LoadIn : MonoBehaviour
{
    private float timer;
    private float timerStart = 1;
    public Image image;
    public UnityEvent onFadeOut;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        image.color = new Color(image.color.r, image.color.g, image.color.b, timer);

        if(timer < 0)
        {
            onFadeOut?.Invoke();
            gameObject.GetComponent<LoadIn>().enabled = false;
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
