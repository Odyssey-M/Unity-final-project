using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBack : MonoBehaviour
{
    public void BackScene()
    {
        SceneManager.LoadScene("Menu");  
    }
}
