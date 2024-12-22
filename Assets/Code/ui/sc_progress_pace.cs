using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_progress_pace : MonoBehaviour {
    
    public Transform trContent;
    public Button btnAddRec;
    public Button btnGradePage;
    public Button btnScalePage;
    public Button btnScoreList;


    private void Start() {
        btnAddRec.onClick.AddListener(Engine.ins.CreateRec);
        btnScoreList.onClick.AddListener(Engine.ins.ShowScoreList);
        btnGradePage.onClick.AddListener(Engine.ins.ShowGradePage);
        btnScalePage.onClick.AddListener(Engine.ins.ShowScalePage);
        
        if (Engine.ctrl.recs != null) {
            Engine.ui.DeleteDiv(trContent);
            for (int i = 0; i < Engine.ctrl.recs.Count; i++) {

                var script =  Engine.ui.MakeInstance(Engine.ui.pr_rec, trContent);
                script.GetComponent<ui_rec>().rec = Engine.ctrl.recs[i];
                // script.GetComponent<ui_rec>()._n = i;
            }
        }
    }




}
