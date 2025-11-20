using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour {

    public float Tension;
    private bool _pressed;
    public Transform RopeTransform;
    public Vector3 RopeNearLocalPosition;
    public Vector3 RopeFarLocalPosition;
    public AnimationCurve RopeReturnAnimation;
    public float ReturnTime;
    public Arrow CurrentArrow=null;
    public float ArrowSpeed;
    public AudioSource ArrowAudio;
    public AudioSource BowAudio;
    public Animator BowAnimator; 


    //private int ArrowIndex = 0;
    private List<Arrow> ArrowsPool=new List<Arrow>();
    public GameObject ar;



    void Start () {
       RopeNearLocalPosition = RopeTransform.localPosition;
    }

	// Update is called once per frame
	void Update () {
        float screenPosition_x = Input.mousePosition.x;
        float screenPosition_y = Input.mousePosition.y;

        if(screenPosition_x > 90*Screen.width/100 && screenPosition_y<Screen.width/10)
         return;
       
        if (Input.GetMouseButtonDown(0)) {
            _pressed=true;

            BowAnimator.SetBool("isDrawing", true);

            if(CurrentArrow ==null)
              CurrentArrow=Instantiate(ar).GetComponent<Arrow>();
              Debug.Log("new arrow!");

            CurrentArrow.SetToRope(RopeTransform , transform);

            BowAudio.pitch=Random.Range(0.8f , 1.2f);
            BowAudio.Play();
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            _pressed=false;
        
            BowAnimator.SetBool("isDrawing", false);
           
            StartCoroutine(RopeReturn());
            CurrentArrow.Shot(ArrowSpeed * Tension);
            Tension=0;

            BowAudio.Stop();

            ArrowAudio.pitch=Random.Range(0.8f , 1.2f);
            ArrowAudio.Play();
            CurrentArrow=null;
        }

        if(_pressed)
        {
            if(Tension<1f)
            {
                Tension += Time.deltaTime;
            }
            RopeTransform.localPosition=Vector3.Lerp(RopeNearLocalPosition , RopeFarLocalPosition , Tension);
        }
    }

   IEnumerator RopeReturn() 
   {
        Vector3 startLocalPosition = RopeTransform.localPosition;
        for (float f = 0; f < 1f; f += Time.deltaTime / ReturnTime) {
            RopeTransform.localPosition = Vector3.LerpUnclamped(startLocalPosition, RopeNearLocalPosition, RopeReturnAnimation.Evaluate(f));
            yield return null;
        }
        RopeTransform.localPosition = RopeNearLocalPosition;
        Tension = 0f; 


    }
    

    
}