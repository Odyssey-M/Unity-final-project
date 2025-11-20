using UnityEngine;

public class GetAccess : MonoBehaviour
{
    public int requiredTime = 1;
    private Collider hillCollider;

    void Start()
    {
        hillCollider = GetComponent<Collider>();
        
    }

    public void CheckValue(int Time)
    {
        if (Time == requiredTime)
        {
            Debug.Log("Correct target hit! Hill " + requiredTime + " is now passable.");
            hillCollider.isTrigger = true;
        }
    }


}
