using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sc_score_list : MonoBehaviour {

    public Transform trContent;
    public Button btnAddScore;
    public Button btnProgress;
    public Button btnGradePage;
    public Button btnScalePage;
    
    public Transform trPopup;
    public Image iSts;
    public TextMeshProUGUI  tCode;
    public TMP_InputField iComposer;
    public TMP_InputField iTitle;
    public TMP_InputField iStart;
    public TMP_InputField iFinish;
    public Button btnSave;
    public Button btnCancel;
    
    public Button btnSTm;
    public Button btnSTp;
    public Button btnETm;
    public Button btnETp;
    public Button btnST;
    public Button btnET;
    
    void Start() {
        
        btnAddScore.onClick.AddListener(Engine.ins.CreateScore);
        btnProgress.onClick.AddListener(Engine.ins.ShowProgressPace);
        btnScalePage.onClick.AddListener(Engine.ins.ShowScalePage);
        btnGradePage.onClick.AddListener(Engine.ins.ShowGradePage);
        
        btnST.onClick.AddListener(SetSTCurrent);
        btnET.onClick.AddListener(SetETCurrent);
        
        btnETm.onClick.AddListener(MinusET);
        btnETp.onClick.AddListener(PlusET);
        
        btnSTm.onClick.AddListener(MinusST);
        btnSTp.onClick.AddListener(PlusST);
        
        trPopup.gameObject.SetActive(false);
        btnSave.onClick.AddListener(SaveChange);
        btnCancel.onClick.AddListener(CancelChange);

        FillScoreList();
        
    }

    private void PlusST() {
        iStart.text = DateTime.Parse(iStart.text).AddDays(1).ToString("dd.MM.yyyy");

    }

    private void MinusST() {
        iStart.text = DateTime.Parse(iStart.text).AddDays(-1).ToString("dd.MM.yyyy");

    }

    private void PlusET() {
        iFinish.text = DateTime.Parse(iFinish.text).AddDays(1).ToString("dd.MM.yyyy");
    }

    private void MinusET() {
        iFinish.text = DateTime.Parse(iFinish.text).AddDays(-1).ToString("dd.MM.yyyy");
    }

    private void SetETCurrent() {
        iFinish.text = DateTime.Today.ToString("dd.MM.yyyy");

    }

    private void SetSTCurrent() {
        iStart.text = DateTime.Today.ToString("dd.MM.yyyy");

    }

    private void FillScoreList() {
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

    private void SaveChange() {
        trPopup.gameObject.SetActive(false);
        Controller.stsScoreChange = 0;
        Logic.ChangeScore(tCode.text, iComposer.text, iTitle.text, iStart.text, iFinish.text);
        Engine.ins.SaveData();
        Engine.ui.updScoreList = true;
    }

    private void CancelChange() {
        trPopup.gameObject.SetActive(false);
        Controller.stsScoreChange = 0;
    }

    private void FixedUpdate() {
        RefreshInfo();
    }

    private void RefreshInfo() {
        if (Controller.stsScoreChange == 1) {
            trPopup.gameObject.SetActive(true);
            tCode.text = Controller.actualScore.Code;
            iComposer.text = Controller.actualScore.Composer;
            iTitle.text = Controller.actualScore.Title;
            iStart.text = Controller.actualScore.StartTime.ToString("dd.MM.yyyy");
            iFinish.text = Controller.actualScore.EndTime.ToString("dd.MM.yyyy");
            Controller.stsScoreChange = 2;
        }

        if (Engine.ui.updScoreList) {
            FillScoreList();
            Engine.ui.updScoreList = false;
        }
    }
}
