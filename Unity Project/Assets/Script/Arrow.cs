using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Arrow : MonoBehaviour {

   public Rigidbody rb;
   public TrailRenderer trailRenderer;
   public TextMeshProUGUI TimeText;


    public void SetToRope(Transform ropeTransform , Transform bow) {
       transform.parent=ropeTransform;
       transform.localPosition=Vector3.zero;
       transform.localRotation=Quaternion.identity;

       rb.useGravity = true; 
       rb.isKinematic=true;
       trailRenderer.enabled=false;
    }

    public void Shot(float velocity) {
      transform.parent=null;
      rb.isKinematic=false;
      rb.linearVelocity=transform.forward * velocity;
      trailRenderer.Clear();
      trailRenderer.enabled=true;
      //Destroy(CurrentArrow , 5f);

    }


  void OnCollisionEnter(Collision other)
    {

      if(other.transform.tag=="Target")
       {
          rb.linearVelocity=Vector3.zero;
          rb.isKinematic=true;
          //Debug.Log("Hit Target!");

          Targetshoot targetScript = other.gameObject.GetComponent<Targetshoot>();
            if (targetScript != null)
            {
                int Time = targetScript.Time;   
                TimeText.text = Time.ToString();
            }

       }


    }

}
