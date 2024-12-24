using System.Collections;
using TMPro;
using UnityEngine;

public class ui_header : MonoBehaviour {
    
	public TextMeshProUGUI  tGrade;
	public TextMeshProUGUI  tPrc;
	public TextMeshProUGUI  tHead;


	private void Start() {
		StartCoroutine(ExecuteTasks());
	}

	private IEnumerator ExecuteTasks() {
		yield return new WaitForSeconds(0.001f); // Wait for 1 second
		DisplayData();
	}

	private void DisplayData() {

		tHead.text = Logic.GetPageName();
		
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
