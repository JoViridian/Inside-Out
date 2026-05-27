using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void DoStartLoad(string a)
    {
        SceneManager.LoadScene(a);
    }
}
