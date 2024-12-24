using UnityEngine;
using UnityEngine.UI;

public class sc_scale_page : MonoBehaviour {
    
    public Button btnScoresList;
    public Button btnProgress;
    public Button btnGradePage;
    public Button btnAddRec;

	private void Start() {

		Engine.pageIdx = 3;

		btnScoresList.onClick.AddListener(Engine.ShowScoreList);
		btnProgress.onClick.AddListener(Engine.ShowProgressPace);
		btnGradePage.onClick.AddListener(Engine.ShowGradePage);
		btnAddRec.onClick.AddListener(Engine.CreateRec);
		
	}

}
