using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class KnockKnock : MonoBehaviour
{
    public GameObject imagePopUp;
    private Image imageMain;
    public AudioClip knock;
    public List<Sprite> newspaper;
    public UnityEvent onActive;
    public UnityEvent badEnd;
    [HideInInspector] public int imageCount;
    private float timer;
    private bool interacted;
    public float timerRepeat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imageCount = 0;
        GameManager.Instance.starAmount = 0;
        timer = timerRepeat;
        interacted = false;
        imageMain = imagePopUp.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.camState && imageCount < newspaper.Count)
        {
            DoTimer();
            //Debug.Log("Countdown");
        }

        if (imageCount <= newspaper.Count)
        {
            imageMain.sprite = newspaper[imageCount];
            //Debug.Log(imageCount);
        }
        else
        {
            imageMain.sprite = newspaper[newspaper.Count];
        }

        GameManager.Instance.starAmount = imageCount;
    }

    void DoTimer()
    {
        if(timer < 0)
        {
            timer = timerRepeat;
            DoMaxCheck();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void SwapPolarity()
    {
        interacted = !interacted;
    }

    void DoMaxCheck()
    {
        if (imageCount < newspaper.Count && !interacted)
        {
            SwapPolarity();
            GameManager.Instance.PlayClip(knock, 1);
            onActive.Invoke();
        }
        else
        {
            badEnd.Invoke();
        }
    }

    public void UpdatePaper()
    {
        imageCount++;
        interacted = !interacted;
    }
}
