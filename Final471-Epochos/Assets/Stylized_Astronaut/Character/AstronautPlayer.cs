using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

    public class AstronautPlayer : MonoBehaviour {

        private Animator anim;
        private CharacterController controller;

        public float speed = 600.0f;
        public float turnSpeed = 400.0f;
        private Vector3 moveDirection = Vector3.zero;
        public float gravity = 20.0f;

        public float jumpSpeed = 8.0f;
		public float jumpHeight = 3.0f;
        private bool isJumping = false;
        private float pushForce; 

        void Start () {
            controller = GetComponent <CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void Update (){
           
            if(controller.isGrounded){
              
                moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

                if (Input.GetButtonDown("Jump")) {
                   
                    anim.SetTrigger("Jump");
					moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);                
                    isJumping = true;
                }
            }

         
            moveDirection.y -= gravity * Time.deltaTime;

           
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

           
            controller.Move(moveDirection * Time.deltaTime);

         
            UpdateAnimator();
        }

        void UpdateAnimator() {
            
            if (Input.GetAxis("Vertical") != 0) {
                anim.SetInteger("AnimationPar", 1); 
            }  else {
                anim.SetInteger("AnimationPar", 0); 
            }
        }


    }
}
