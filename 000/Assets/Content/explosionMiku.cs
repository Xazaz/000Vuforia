using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]	//or other collider
public class explosionMiku : MonoBehaviour {
	// based on: http://answers.unity3d.com/questions/7555/how-do-i-call-a-function-in-another-gameobjects-sc.html
	// or: http://forum.unity3d.com/threads/calling-function-from-other-scripts-c.57072/
	private bool onOff = false;
	private bool uncheck = true;
	public GameObject Miku;
	public GameObject greenBoxExplodeObject;
	public GameObject Burst2Effect;
	public GameObject Aura2Effect;
	public AudioClip explosionSound;
	void Start () {
		Miku.SetActive(false);
		Burst2Effect.SetActive(false);
		Aura2Effect.SetActive(false);
	}
	
	
	void Update () { 	// Update is called once per frame
		
		if (onOff && uncheck) {
			Debug.Log("once");
			onOff = false;
			//GameObject.Find("DetonatorCrazysparks").GetComponent<Detonator>().Explode(); 
			gameObject.GetComponent<AudioSource>().clip =  explosionSound;
			gameObject.GetComponent<AudioSource>().Play();
			Destroy (greenBoxExplodeObject);
			Burst2Effect.SetActive(true);
			Miku.SetActive(true);
			Aura2Effect.SetActive(true);
			gameObject.GetComponent<BoxCollider>().enabled = false;
			Miku.GetComponent<Animation>()["mixamo.com"].speed = 1.5f;
		}
		if (greenBoxExplodeObject == null && !Miku.GetComponent<Animation>().isPlaying) {	

			Debug.Log("check");
			Miku.GetComponent<Animation>().Play ("mixamo.com");
			uncheck = false;
			Burst2Effect.SetActive(false);
		}
	}
	
	void OnMouseDown() {
		if(onOff)
			onOff = false;
		else
			onOff = true;
	}
	
}