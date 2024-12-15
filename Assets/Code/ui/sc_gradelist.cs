using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_gradelist : MonoBehaviour {

    public Transform trContent;
    public Button btnAddScore;
    public Button btnGradList;
    public Button btnInfo;
    
    void Start() {
        
        btnAddScore.onClick.AddListener(Engine.ins.CreateScore);
        btnGradList.onClick.AddListener(Engine.ins.ShowGradeList);
    
        if (Engine.ctrl.scores != null) {
            Engine.ui.DeleteDiv(trContent);
            for (int i = 0; i < Engine.ctrl.scores.Count; i++) {

                var script =  Engine.ui.MakeInstance(Engine.ui.pr_score, trContent);
                script.GetComponent<ui_score>()._score = Engine.ctrl.scores[i];
                script.GetComponent<ui_score>()._n = i;
            }
        }
    }





}
