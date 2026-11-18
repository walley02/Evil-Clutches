using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void Loadscenebyname(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}
