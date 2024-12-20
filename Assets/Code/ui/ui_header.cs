using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ui_header : MonoBehaviour {
    
	public TextMeshProUGUI  tGrade;
	public TextMeshProUGUI  tPrc;
	public TextMeshProUGUI  tHead;
	
	
	void Start() {
		StartCoroutine(ExecuteTasks());
	}

	IEnumerator ExecuteTasks() {
		yield return new WaitForSeconds(0.001f); // Wait for 1 second
		DisplayData();
	}

	private void DisplayData() {
		var l = Logic.GetCurrentGrade();
		int g;
		
		if (l < 50) {
			g = l;
		} else {
			g = l / 10;
		}

		tGrade.text = g.ToString();
		tPrc.text = Logic.CountPrcByGrade(Logic.GetCurrentGrade()) + "%";

	}
}
