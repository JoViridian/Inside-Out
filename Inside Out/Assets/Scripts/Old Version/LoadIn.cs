using UnityEngine;
using UnityEngine.UI;

public class LoadIn : MonoBehaviour
{
    private float timer;
    private float timerStart = 1;
    public Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        image.color = new Color(0, 0, 0, timer);

        if(timer < 0)
        {
            gameObject.GetComponent<LoadIn>().enabled = false;
        }
    }
}
