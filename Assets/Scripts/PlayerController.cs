using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed; 
	private int count; 
	public Text countText; 
	public Text winText; 

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0; 
		SetCountText(); 
		winText.text = ""; 
	}

	void FixedUpdate()
	{
		float moveHoritxontal = Input.GetAxis ("Horizontal"); // x value
		float movehVertixal = Input.GetAxis ("Vertical"); // z value

		Vector3 movement = new Vector3 (moveHoritxontal, 0.0f, movehVertixal); 

		bool didJump = Input.GetKey (KeyCode.Space);
		if (didJump) {
			movement.y = 5.0f;
			System.Console.Out.WriteLine ("Jump happened.");
			winText.text = "You jumped!!!"; 
		}

		//leave force mode at default by omitting it from code
		rb.AddForce(movement * speed);

	}




	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false); 
			//count = count + 1; 
			count++; 
			SetCountText(); 
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString (); 
		if (count >= 14) {
			winText.text = "You Win!!!"; 
		};
	}

	//

}

