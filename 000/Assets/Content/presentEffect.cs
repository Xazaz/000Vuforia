using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]	//or other collider
public class presentEffect : MonoBehaviour {
	// based on: http://answers.unity3d.com/questions/7555/how-do-i-call-a-function-in-another-gameobjects-sc.html
	// or: http://forum.unity3d.com/threads/calling-function-from-other-scripts-c.57072/
	private bool onOff = false;
	public GameObject Aura1Effect;
	void Start () {
		Aura1Effect.SetActive (false);
	}
	

	void Update () { 	// Update is called once per frame

		if (onOff) {
			Debug.Log("boom");
			onOff = false;
			Aura1Effect.SetActive (true);
			gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}

	void OnMouseDown() {
		if(onOff)
			onOff = false;
		else
			onOff = true;
	}

}