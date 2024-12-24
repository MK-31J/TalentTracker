using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ui_rec : MonoBehaviour {
    
    
	public Rec rec;
	public TextMeshProUGUI  tDay;
	public TextMeshProUGUI  tWorkTime;
	public Transform trRep;
	public Transform trExc;
	public Button bChange;


	void Start() {
        
		StartCoroutine(ExecuteTasks());
        
	}

	IEnumerator ExecuteTasks() {
		yield return new WaitForSeconds(0.001f); // Wait for 1 second
		DisplayData();
	}
    
	private void DisplayData() {
 
		bChange.onClick.AddListener(ChangeData);
		
		tDay.text = rec.Day.ToString("dd.MM.yy");
		var workTime = 0;
		var t = 0;
		var e = 0;
		foreach (var v in rec.Exercises) {
			workTime += v.Quarter * 15;
			if (!Logic.IsScoreExcByCode(v.Code)) {
				trRep.GetChild(t).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = v.Code;
				ShowQuarters(trRep.GetChild(t).GetChild(1) ,v.Quarter);
				t++;
			} else {
				trExc.GetChild(e).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = v.Code;
				ShowQuarters(trExc.GetChild(e).GetChild(1) ,v.Quarter);
				e++;
			}

		}

		
		tWorkTime.text = workTime.ToString();
		
        
	}

	private void ChangeData() {
		Controller.actualRec = rec;
		Controller.stsRecChange = 1;
	}

	private void ShowQuarters(Transform tr, int vQuarter) {
		for (int i = 0; i < tr.childCount; i++) {
			if (i <= vQuarter-1) {
				tr.GetChild(i).GetComponent<RawImage>().color = Meta.clHighlight;
			}
		}
	}
}
