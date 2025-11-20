using UnityEngine;
using UnityEngine.SceneManagement; // 用于重新加载场景
using UnityEngine.UI; // 用于显示UI

public class GroundCheck : MonoBehaviour
{
    public GameObject failUI; // 拖入你的Fail UI
    public float restartDelay = 2f; // 延迟重启的时间（秒）

    private bool hasFailed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !hasFailed)
        {
            hasFailed = true; // 防止重复触发

            Debug.Log("Player failed!");
            if (failUI != null)
                failUI.SetActive(true);

            // 延迟重新加载当前场景
            Invoke(nameof(RestartGame), restartDelay);
        }
    }

    void RestartGame()
    {
        // 重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
