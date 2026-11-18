using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void Loadscenebyname(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
}
