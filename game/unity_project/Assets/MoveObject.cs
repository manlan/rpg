using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
		public GameObject pointer;
		public Character character;

		void Start ()
		{
				pointer = Instantiate (pointer, Vector3.zero, Quaternion.Euler (Vector3.right * 90)) as GameObject;
				pointer.SetActive (false);
		}
	
		void OnMouseOver ()
		{
				pointer.SetActive (true);
				pointer.transform.position = MouseHitPoint () + Vector3.up * 3;
		}
	
		void OnMouseExit ()
		{
				pointer.SetActive (false);
		}




		// handle movement

		void OnMouseUpAsButton ()
		{
				character.MoveTo (FindDestination ());
		}
	
		void OnMouseDrag ()
		{
				character.MoveTo (FindDestination ());
		}

		private Vector3 FindDestination ()
		{
				Vector3 hitPoint = MouseHitPoint ();
				
				if (hitPoint != Vector3.zero) {
						return new Vector3 (hitPoint.x, 1 + hitPoint.y, hitPoint.z);
				} else {
						return Vector3.zero;
				}
		}

		private Vector3 MouseHitPoint ()
		{
				RaycastHit hit = new RaycastHit ();
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				collider.Raycast (ray, out hit, 1000.0f);
				return hit.point;
		}
}
