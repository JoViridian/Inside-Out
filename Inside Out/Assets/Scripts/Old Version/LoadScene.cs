using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void DoStartLoad()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
