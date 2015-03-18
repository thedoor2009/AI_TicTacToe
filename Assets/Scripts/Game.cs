using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button(new Rect(310,180,200,30), "Restart Level"))
		{
			
			Application.LoadLevel (Application.loadedLevelName);
			
		}
	}
}
