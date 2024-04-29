using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class AstronautPlayer : MonoBehaviour {

        private Animator anim;
        public Transform cam; 
        public CharacterController controller;
        public Rigidbody playerRigid;
        public float turnSmoothTime = 0.1f;
        float turnSmoothVelocity; 
        public float speed = 600.0f;
        public float turnSpeed = 400.0f;
        private Vector3 moveDirection = Vector3.zero;
        public float gravity = 20.0f;

        public float jumpSpeed = 8.0f;
		public float jumpHeight = 3.0f;
        private bool isJumping = false;
        private float pushForce; 
        public string sceneName;


        void Start () {
            controller = GetComponent <CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("projectile"))
                {
                    KillPlayer();
                }
        }

        private void KillPlayer()
        {
            SceneManager.LoadScene(sceneName); 
         
        }

        void Update () {
           
            if(controller.isGrounded){
              
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalInput = Input.GetAxisRaw("Vertical");
                Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized; 
                if (movement.magnitude >= 0.1f) {
                    float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cam.eulerAngles.y; 
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); 
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
                    //controller.Move(moveDir.normalized * speed * Time.deltaTime); 
                }
                movement = transform.TransformDirection(movement);
                movement *= speed;
                moveDirection = movement;

                if (Input.GetButtonDown("Jump")) {
                   
                    anim.SetTrigger("Jump");
					moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);                
                    isJumping = true;
                }
            }
            moveDirection.y -= gravity * Time.deltaTime;
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

    

