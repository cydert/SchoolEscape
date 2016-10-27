using UnityEngine;
using System.Collections;
// : MonoBehaviour 
public class Timer{
	private float start;
	private float end;
	public Timer(float end){
		start = Time.time;
		this.end = end;
	}
	float getTime(){
		return Time.time - start;
	}
	public bool getEndIs(){
		if (Time.time - start >= end)
			return true;
		else
			return false;
	}
	/*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	*/
}
