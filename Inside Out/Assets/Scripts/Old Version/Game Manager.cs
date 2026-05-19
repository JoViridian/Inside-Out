using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GM's singleton for easy access throughout the whole project
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        // setup singleton
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
    }

    public GameObject infoBox;
    [SerializeField] private AudioSource sourcePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void PlayClip(AudioClip clip, float volume)
    {
        // create a new audio source
        AudioSource source = Instantiate(sourcePrefab);

        // set its variables
        source.clip = clip;
        source.volume = volume;

        // play the sound
        source.Play();

        // ensure it stays alive, say when we reload RN
        DontDestroyOnLoad(source);

        // destroy GO after play time
        Destroy(source.gameObject, clip.length);
    }
}
