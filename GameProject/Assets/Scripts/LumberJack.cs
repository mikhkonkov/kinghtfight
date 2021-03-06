﻿using UnityEngine;
using System.Collections;

public class LumberJack : MonoBehaviour {
	public double myTimer = 10.0;
	public GUISkin mySkin;
	public Texture reload;
	public Texture cancel;

	double workTimer;
	PlayerProgress progress = new PlayerProgress();
	// Use this for initialization
	void Start () {
		workTimer = myTimer;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		GUI.skin = mySkin;
		if (workTimer > 0) {
			workTimer -= Time.deltaTime;
			GUI.Label (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), ((int)workTimer).ToString ());
		}
		if (workTimer == 0) {
			int playerPoints = progress.getPoints();
			playerPoints += 10;
		}
		if (workTimer <= 0) {
			int playerPoints = progress.getPoints();
			GUI.Label (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "You finished chop-chop! You points: " + playerPoints.ToString());

			if (GUI.Button(new Rect (Screen.width / 2 - 125, Screen.height / 2 + 70, 100, 100), reload)) {
				workTimer = myTimer;
				playerPoints += 10;
				progress.savePoints(playerPoints);
			}
			if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 70, 100, 100), cancel)) {
				playerPoints += 10;
				progress.savePoints(playerPoints);
				Application.LoadLevel(0);
			}
		}
	}

	void chopWood() {
	
	}
}
