using UnityEngine;
using System.Collections;

public class Chess : MonoBehaviour {

	public int x;
	public int y;
	public bool isSet;

	void Start () {
		//x = 0;
		//y = 0;
		isSet = false;
	}

	void Update () {
	
	}

	public bool hasSet(){
		return isSet;
	}

	public void SetChess( int i_x, int i_y ){
		if( i_x >5 || i_y > 5 || i_x < 0 || i_y < 0 ){
			Debug.LogError("Set Chess Wrongly");
			return;
		}

		isSet = true;
		x = i_x;
		y = i_y;
	}

	public int GetX(){
		return x;
	}

	public int GetY(){
		return y;
	}
}
