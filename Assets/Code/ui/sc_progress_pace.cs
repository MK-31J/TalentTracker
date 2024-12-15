using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_progress_pace : MonoBehaviour {
    
    public Transform trContent;
    public Button btnAddRec;
    

    void Start() {
        btnAddRec.onClick.AddListener(CreateRec);
        if (Engine.ctrl.recs != null) {
            Engine.ui.DeleteDiv(trContent);
            for (int i = 0; i < Engine.ctrl.recs.Count; i++) {

                var script =  Engine.ui.MakeInstance(Engine.ui.pr_rec, trContent);
                script.GetComponent<ui_rec>().rec = Engine.ctrl.recs[i];
                // script.GetComponent<ui_rec>()._n = i;
            }
        }
    }

    private void CreateRec() {
        Engine.ins.SetScene("RecCreate");
    }


}
