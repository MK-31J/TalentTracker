using UnityEngine;
using UnityEngine.UI;

public class sc_settings_page : MonoBehaviour {

	public Button btnProgress;
	public Button btnAddRec;
	public Button btnGradePage;
	public Button btnScalePage;
	public Button btnScoreList;
	
	public Button btnExit;

	private void Start() {
		
		Engine.pageIdx = 4;

		btnAddRec.onClick.AddListener(Engine.CreateRec);
		btnProgress.onClick.AddListener(Engine.ShowProgressPace);
		btnScoreList.onClick.AddListener(Engine.ShowScoreList);
		btnGradePage.onClick.AddListener(Engine.ShowGradePage);
		btnScalePage.onClick.AddListener(Engine.ShowScalePage);
		btnExit.onClick.AddListener(Engine.ExitApp);

	}
	
}
