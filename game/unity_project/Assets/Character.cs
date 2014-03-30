using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

		public string nickname;
		private Color originalColor;

		void Start ()
		{
				destination = transform.position;
				originalColor = transform.renderer.materials [1].color;
		}
	
		void OnCollisionEnter ()
		{
				transform.renderer.materials [1].color = Color.red;
		}

		void OnCollisionExit ()
		{	
				transform.renderer.materials [1].color = originalColor;
		}

		void FixedUpdate ()
		{
				transform.Rotate (Vector3.up * 36 * Time.deltaTime);
		}




		// movement
	
		private float velocity = 2.0f;
		private Vector3 destination;

		void Update ()
		{
				if (!transform.position.Equals (destination))
						transform.position = Vector3.Slerp (transform.position, destination, Time.deltaTime * velocity);
		}

		public void MoveTo (Vector3 dest)
		{
				Vector3 possibleDest = new Vector3 (Mathf.Round (dest.x), Mathf.Round (dest.y), Mathf.Round (dest.z));
				
				if (dest == Vector3.zero || destination.Equals (possibleDest))
						return;

				destination = possibleDest;

				// everytime the object changes its destination vector, we MUST tell the
				// server so the object can move in other player's screen too	
				Server.Write(destination.ToString());
		}
}
