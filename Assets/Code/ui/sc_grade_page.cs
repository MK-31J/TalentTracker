using UnityEngine;
using UnityEngine.UI;

public class sc_grade_page : MonoBehaviour {

	public Transform trContent;
	public Button btnScoresList;
	public Button btnProgress;
	public Button btnScalePage;
	public Button btnAddRec;

	void Start() {

		Engine.pageIdx = 2;
		
		btnScoresList.onClick.AddListener(Engine.ShowScoreList);
		btnProgress.onClick.AddListener(Engine.ShowProgressPace);
		btnScalePage.onClick.AddListener(Engine.ShowScalePage);
		btnAddRec.onClick.AddListener(Engine.CreateRec);
		
		if (Engine.ctrl.grades != null) {
			Engine.ui.DeleteDiv(trContent);
			for (int i = 0; i < Engine.ctrl.grades.Count; i++) {

				var script =  Engine.ui.MakeInstance(Engine.ui.pr_grade, trContent);
				script.GetComponent<ui_grade>().grade = Engine.ctrl.grades[i];
			}
		}
	}
}
