using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
   public Rigidbody rb;
   public TrailRenderer trailRenderer;


    public void SetToRope(Transform ropeTransform , Transform bow) {
       transform.parent=ropeTransform;
       transform.localPosition=Vector3.zero;
       transform.localRotation=Quaternion.identity;
        
       rb.isKinematic=true;
       trailRenderer.enabled=false;
    }

    public void Shot(float velocity) {
      transform.parent=null;
      rb.isKinematic=false;
      rb.linearVelocity=transform.forward * velocity;
      trailRenderer.Clear();
      trailRenderer.enabled=true;
      Destroy(gameObject , 5f);

    }


  void OnCollisionEnter(Collision other)
    {

       if(other.transform.tag=="shootable")
       {
          rb.linearVelocity=Vector3.zero;
          rb.isKinematic=true;
       }

    }

}