using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
		private Color originalColor;
	
		void Start ()
		{
				originalColor = transform.renderer.material.color;
		}

		void OnMouseEnter ()
		{ 
				transform.renderer.material.color = Color.red;
		}

		void OnMouseExit ()
		{
				transform.renderer.material.color = originalColor;		
		}
}
