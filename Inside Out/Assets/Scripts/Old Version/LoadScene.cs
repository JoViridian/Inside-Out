using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private float timer;
    private bool doFade = false;
    public Image image;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    { 
        if (doFade)
        {
            image.gameObject.SetActive(true);
            timer += Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, timer);
        }
    }

    public void DoStartLoad(string a)
    {
        SceneManager.LoadScene(a);
    }

    public void DoStartLoadDelay(string a)
    {
        doFade = true;
        StartCoroutine(FadeIn(a));
    }

    IEnumerator FadeIn(string b)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(b);
    }

    public void TurnBlack()
    {
        image.color = new Color(0, 0, 0, 0);
    }
}
