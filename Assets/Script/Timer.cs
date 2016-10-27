using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	private float start;
	private float end;
	Timer(float end){
		start = Time.time;
		this.end = end;
	}
	Timer(float first,float end){
		this.start = first;
		this.end = end;
	}
	float getTime(){
		return Time.time - start;
	}
	bool getEndIs(){
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
