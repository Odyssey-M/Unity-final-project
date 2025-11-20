using UnityEngine;

public class finish : MonoBehaviour
{
    public GameObject congratulationsUI; // 拖入你的UI

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
        
            gameObject.SetActive(false);

           
            if (congratulationsUI != null)
            {
                congratulationsUI.SetActive(true);
            }
        }
    }
}
