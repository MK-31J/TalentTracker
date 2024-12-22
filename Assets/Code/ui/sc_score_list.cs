using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_score_list : MonoBehaviour {

    public Transform trContent;
    public Button btnAddScore;
    public Button btnProgress;
    public Button btnGradePage;
    public Button btnScalePage;
    
    void Start() {
        
        btnAddScore.onClick.AddListener(Engine.ins.CreateScore);
        btnProgress.onClick.AddListener(Engine.ins.ShowProgressPace);
        btnScalePage.onClick.AddListener(Engine.ins.ShowScalePage);
        btnGradePage.onClick.AddListener(Engine.ins.ShowGradePage);
    
        if (Engine.ctrl.scores != null) {
            Engine.ui.DeleteDiv(trContent);
            for (int i = 0; i < Engine.ctrl.scores.Count; i++) {

                var script =  Engine.ui.MakeInstance(Engine.ui.pr_score, trContent);
                script.GetComponent<ui_score>()._score = Engine.ctrl.scores[i];
                script.GetComponent<ui_score>()._n = i;
            }
        }

        RectTransform rectTransform = trContent.GetComponent<RectTransform>();
        Vector2 size = rectTransform.sizeDelta;
        size.y = 95 * Engine.ctrl.scores.Count;
        rectTransform.sizeDelta = size;
        
    }


    


    

}
