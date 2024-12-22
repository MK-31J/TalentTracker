using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_scale_page : MonoBehaviour {
    
    public Button btnScoresList;
    public Button btnProgress;
    public Button btnGradePage;
    public Button btnAddRec;

	void Start() {

		btnScoresList.onClick.AddListener(Engine.ins.ShowScoreList);
		btnProgress.onClick.AddListener(Engine.ins.ShowProgressPace);
		btnGradePage.onClick.AddListener(Engine.ins.ShowGradePage);
		btnAddRec.onClick.AddListener(Engine.ins.CreateRec);
		
	}

}
