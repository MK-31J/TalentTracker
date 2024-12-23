using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sc_progress_pace : MonoBehaviour {
    
    public Transform trContent;
    public Button btnAddRec;
    public Button btnGradePage;
    public Button btnScalePage;
    public Button btnScoreList;
    
    public Transform trPopup;
    public Transform trExc;
    public Button btnCancel;

    private void Start() {
        btnAddRec.onClick.AddListener(Engine.ins.CreateRec);
        btnScoreList.onClick.AddListener(Engine.ins.ShowScoreList);
        btnGradePage.onClick.AddListener(Engine.ins.ShowGradePage);
        btnScalePage.onClick.AddListener(Engine.ins.ShowScalePage);
        
        trPopup.gameObject.SetActive(false);
        btnCancel.onClick.AddListener(CancelChange);
        
        FillRecList();
    }

    
    private void CancelChange() {
        trPopup.gameObject.SetActive(false);
        Controller.stsRecChange = 0;
    }
    
    private void FixedUpdate() {
        RefreshInfo();
    }
    
    private void RefreshInfo() {
        if (Controller.stsRecChange == 1) {
            trPopup.gameObject.SetActive(true);
            for (int i = 0; i < trExc.childCount; i++) {
                trExc.GetChild(i).gameObject.SetActive(true);
                trExc.GetChild(i).GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
            }
            for (int i = 0; i < trExc.childCount; i++) {
                if (i < Controller.actualRec.Exercises.Count) {
                    trExc.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                                                    Controller.actualRec.Exercises[i].Code;
                    var n = i;
                    trExc.GetChild(i).GetChild(1).GetComponent<Button>().onClick.AddListener(
                                                    delegate { DeleteExc(Controller.actualRec.Exercises[n].Code); });
                } else {
                    trExc.GetChild(i).gameObject.SetActive(false);
                }
            }
            Controller.stsRecChange = 2;
        }
    
        if (Engine.ui.updRecList) {
            FillRecList();
            Engine.ui.updRecList = false;
        }
    }

    private void DeleteExc(string s) {
        trPopup.gameObject.SetActive(false);
        Controller.stsRecChange = 0;
        Logic.ChangeRec(Controller.actualRec.Day, s);
        Engine.ins.SaveData();
        Engine.ui.updRecList = true;
    }

    private void FillRecList() {
        
        if (Engine.ctrl.recs != null) {
            Engine.ui.DeleteDiv(trContent);
            for (int i = 0; i < Engine.ctrl.recs.Count; i++) {

                var script =  Engine.ui.MakeInstance(Engine.ui.pr_rec, trContent);
                script.GetComponent<ui_rec>().rec = Engine.ctrl.recs[i];
                // script.GetComponent<ui_rec>()._n = i;
            }
        }
        
        RectTransform rectTransform = trContent.GetComponent<RectTransform>();
        Vector2 size = rectTransform.sizeDelta;
        size.y = 150 * Engine.ctrl.scores.Count;
        rectTransform.sizeDelta = size;
    }
}
