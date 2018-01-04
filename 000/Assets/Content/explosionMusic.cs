using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]	//or other collider

public class explosionMusic : MonoBehaviour {
	// based on: http://answers.unity3d.com/questions/7555/how-do-i-call-a-function-in-another-gameobjects-sc.html
	// or: http://forum.unity3d.com/threads/calling-function-from-other-scripts-c.57072/
	private bool onOff = false;
	private bool uncheck = true;
	public AudioClip explosionSound;
	public AudioClip backgroundSound;
	public GameObject redExplodeObject;
	public GameObject Burst2Efffect;
	public GameObject Heal2Efffect;
	
	//	[RequireComponent(typeof(AudioSource))]
	void Start () {
		//AudioSource audio = GetComponent<AudioSource>();
		Burst2Efffect.SetActive(false);
		Heal2Efffect.SetActive(false);
	}
	
	
	void Update () { 	// Update is called once per frame
		
		if (onOff && uncheck) {
			Debug.Log("boom");
			onOff = false;
			redExplodeObject.SetActive(false);
			Burst2Efffect.SetActive(true);
			Heal2Efffect.SetActive(true);
			gameObject.GetComponent<AudioSource>().clip =  explosionSound;
			gameObject.GetComponent<AudioSource>().Play();
			Destroy (redExplodeObject);
			gameObject.GetComponent<BoxCollider>().enabled = false;

			//Destroy (GameObject.Find ("Cube")); //Destroy (gameObject);
		}
		
		if (redExplodeObject == null && !gameObject.GetComponent<AudioSource>().isPlaying) {	
			Debug.Log("check music");
			gameObject.GetComponent<AudioSource>().clip =  backgroundSound;
			gameObject.GetComponent<AudioSource>().Play();
			//Miku.GetComponent<Animation>().Play ("rumba_dancing");
			uncheck = false;
		}
	}
	
	void OnMouseDown() {
		if(onOff)
			onOff = false;
		else
			onOff = true;
	}
	
}