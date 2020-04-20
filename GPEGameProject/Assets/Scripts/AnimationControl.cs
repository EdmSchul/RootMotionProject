using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {

    private float speed = 4f;

    private Animator animator;

    Vector3 LookTarget;

    float WarpTimer = 10;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	private void Update () {
        
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1);
        input *= speed;
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.z);

        LookToPoint();
        WarpDash();
        if (WarpTimer < 10) {
            WarpTimer += Time.deltaTime;
        }
        print(WarpTimer);
    }

    void LookToPoint() {
        Ray LookToRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit LookHit;
        if (Physics.Raycast(LookToRay, out LookHit)) {
            LookTarget = LookHit.point;
        } 
        transform.LookAt(LookTarget);
    }

    void WarpDash() {
        if (WarpTimer >= 10) 
        {
            if (transform.position.x < 85 && transform.position.x > 5)
            {
                if (transform.position.z < 85 && transform.position.z > 5)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        transform.position += transform.forward * 5;
                        WarpTimer = 0;
                    }
                }
            }
        }
        
    }
}
