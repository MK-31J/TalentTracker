using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public TextMeshProUGUI tTop;
    public Transform trExc;
    public Button btnCancel;

    private void Start() {
        
        Engine.pageIdx = 0;
        
        btnAddRec.onClick.AddListener(Engine.CreateRec);
        btnScoreList.onClick.AddListener(Engine.ShowScoreList);
        btnGradePage.onClick.AddListener(Engine.ShowGradePage);
        btnScalePage.onClick.AddListener(Engine.ShowScalePage);
        
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
            tTop.text = Controller.actualRec.Day.ToString("dd.MM.yyyy");
            // reset previous listener
            for (int i = 0; i < trExc.childCount; i++) {
                trExc.GetChild(i).gameObject.SetActive(true);
                trExc.GetChild(i).GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
            }
            // display popup exercises
            for (int i = 0; i < trExc.childCount; i++) {
                if (i < Controller.actualRec.Exercises.Count) {
                    trExc.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                                                                    Controller.actualRec.Exercises[i].Code;
                    var n = i;
                    trExc.GetChild(i).GetChild(1).GetComponent<Button>().onClick.AddListener(
                        delegate { IncPractice(Controller.actualRec.Exercises[n].Code); });
                    trExc.GetChild(i).GetChild(2).GetComponent<Button>().onClick.AddListener(
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

    private void IncPractice(string s) {
        trPopup.gameObject.SetActive(false);
        Controller.stsRecChange = 0;
        Logic.ChangePractice(Controller.actualRec.Day, s);
        Engine.SaveData();
        Engine.ui.updRecList = true;
    }

    private void DeleteExc(string s) {
        trPopup.gameObject.SetActive(false);
        Controller.stsRecChange = 0;
        Logic.ChangeRec(Controller.actualRec.Day, s);
        Logic.CheckRecsForEmpty();
        Engine.SaveData();
        Engine.ui.updRecList = true;
    }

    private void FillRecList() {
        
        if (Engine.ctrl.recs != null) {
            Engine.ui.DeleteDiv(trContent);
            var sortedRecs = Engine.ctrl.recs.OrderBy(r => r.Day).ToList();
            foreach (var t in sortedRecs) {
                var script =  Engine.ui.MakeInstance(Engine.ui.pr_rec, trContent);
                script.GetComponent<ui_rec>().rec = t;
            }
        }
        
        var rectTransform = trContent.GetComponent<RectTransform>();
        var size = rectTransform.sizeDelta;
        size.y = 150 * Engine.ctrl.recs.Count;
        rectTransform.sizeDelta = size;
    }
}
