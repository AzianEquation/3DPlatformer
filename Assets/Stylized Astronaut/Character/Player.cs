using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
        private Vector3 jumpDirection = Vector3.zero;
		public float gravity = 20.0f;
        public float jumpSpeed = 10.0f;
    //private Rigidbody rigid;
    public Text levelText;
    public Text winText;
		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
            levelText.text = "Platform 0";
            winText.text = "";
            //rigid = GetComponent<Rigidbody>();
		}

		void FixedUpdate (){
			if (Input.GetKey ("w") || Input.GetKey("up")) {
				anim.SetInteger ("AnimationPar", 1);
			}  else {
				anim.SetInteger ("AnimationPar", 0);
			}

            // if player is on ground then move forward or jump
			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                jumpDirection = transform.up * Input.GetAxis("Jump") * jumpSpeed;
                controller.Move(jumpDirection * Time.deltaTime);
        }

			float turn = Input.GetAxis("Horizontal");
            
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}
    
    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Entered OnTriggerEnter: " + coll.gameObject.name);
        if (coll.gameObject.name.Equals("reset"))
        {
            Debug.Log("Trigger with restart");
            //float force = coll.gameObject.GetComponent<Enemy>().force;
            //rigid.AddForce(coll.gameObject.GetComponent<Rigidbody>().velocity * force);
            // move player to original position
            //transform.position = start;
            Invoke("restart",0.3f);
        }
        if (coll.gameObject.name.Equals("Platform1"))
        {
            levelText.text = "Platform 1";
        }
        if (coll.gameObject.name.Equals("Platform2"))
        {
            levelText.text = "Platform 2";
        }
        if (coll.gameObject.name.Equals("Platform3"))
        {
            levelText.text = "Platform 3";
        }
        if (coll.gameObject.name.Equals("Platform4"))
        {
            levelText.text = "Platform 4";
        }
        if (coll.gameObject.name.Equals("Platform5"))
        {
            levelText.text = "Platform 5";
        }
        if (coll.gameObject.name.Equals("PlatformWin"))
        {
            levelText.text = "Platform 6";
            winText.text = "You Escaped the Aliens!";
            Invoke("restart", 5);
        }
    }
    void restart()
    {
        SceneManager.LoadScene("3dPlatformer");
    }

}
