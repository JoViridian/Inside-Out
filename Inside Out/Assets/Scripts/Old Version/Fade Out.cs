using UnityEngine;
using TMPro;

public class FadeOut : MonoBehaviour
{
    public float lifetimeStart = 3.0f;
    private float lifetime;
    public TextMeshProUGUI text;

    void Start()
    {
        lifetime = lifetimeStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime -= Time.deltaTime;
        }

        if (lifetime < 1)
        {
            text.color = new Color(0.1f, 0.67f, 0.33f, lifetime);
        }
    }
}
