using UnityEngine;

public class Targetshoot : MonoBehaviour
{
    public int Time = 1;            
    public GetAccess getAccess;     

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Arrow"))
        {
            Debug.Log("Hit Target! Value = " + Time);

            if (getAccess != null)
            {
                getAccess.CheckValue(Time);
            }

        }
    }
}
