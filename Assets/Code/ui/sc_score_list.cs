using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sc_score_list : MonoBehaviour {

    public Transform trContent;
    public Button btnAddScore;
    public Button btnProgress;
    public Button btnGradePage;
    public Button btnScalePage;
    public Button btnGradeScoreChange;
    
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

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    
    public float swipeThreshold = 50f;
    
    void Start() {
        
        Engine.pageIdx = 1;
        Logic.UpdateScoreSts();
        
        btnAddScore.onClick.AddListener(Engine.CreateScore);
        btnProgress.onClick.AddListener(Engine.ShowProgressPace);
        btnScalePage.onClick.AddListener(Engine.ShowScalePage);
        btnGradePage.onClick.AddListener(Engine.ShowGradePage);
        
        btnST.onClick.AddListener(SetStCurrent);
        btnET.onClick.AddListener(SetFinCurrent);
        
        btnETm.onClick.AddListener(MinusET);
        btnETp.onClick.AddListener(PlusET);
        
        btnSTm.onClick.AddListener(MinusST);
        btnSTp.onClick.AddListener(PlusST);
        
        trPopup.gameObject.SetActive(false);
        btnSave.onClick.AddListener(SaveChange);
        btnCancel.onClick.AddListener(CancelChange);
        
        btnGradeScoreChange.onClick.AddListener(GradeScoreShowChange);

        FillScoreList();
        
    }

    private void GradeScoreShowChange() {
        if (Controller.showGradeScores < 12) {
            Controller.showGradeScores++;
        } else {
            Controller.showGradeScores = 1;
        }
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

    private void SetFinCurrent() {
        iFinish.text = DateTime.Today.ToString("dd.MM.yyyy");
        btnETm.interactable = true;
    }

    private void SetStCurrent() {
        iStart.text = DateTime.Today.ToString("dd.MM.yyyy");
        btnSTm.interactable = true;
    }

    private void FillScoreList() {
        if (Engine.ctrl.scores == null) return;
        Engine.ui.DeleteDiv(trContent);
        var filteredScores = Engine.ctrl.scores.Where(v => v.Grade == Controller.showGradeScores).OrderBy(v => v.Code).ToList();
        for (var i = 0; i < filteredScores.Count; i++) {

            var script =  Engine.ui.MakeInstance(Engine.ui.pr_score, trContent);
            script.GetComponent<ui_score>()._score = filteredScores[i];
            script.GetComponent<ui_score>()._n = i;
        }

        // RectTransform rectTransform = trContent.GetComponent<RectTransform>();
        // Vector2 size = rectTransform.sizeDelta;
        // size.y = 95 * Engine.ctrl.scores.Count;
        // rectTransform.sizeDelta = size;
    }

    private void SaveChange() {
        trPopup.gameObject.SetActive(false);
        Controller.stsScoreChange = 0;
        Logic.ChangeScore(tCode.text, iComposer.text, iTitle.text, iStart.text, iFinish.text);
        Logic.UpdateScoreSts();
        Engine.SaveData();
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
            
            if (DateTime.Parse(iStart.text).Year < 2000) {
                btnSTm.interactable = false;
            }
        
            if (DateTime.Parse(iFinish.text).Year < 2000) {
                btnETm.interactable = false;
            }
            
            Controller.stsScoreChange = 2;
        }

        if (Engine.ui.updScoreList) {
            FillScoreList();
            Engine.ui.updScoreList = false;
        }
    }
    
    private void Update() {
        if (SwapDirection() == 1) {
            Controller.showGradeScores++;
            FillScoreList();


        } else if (SwapDirection() == 2) {
            Controller.showGradeScores--;
            FillScoreList();

        }
    }

    private int SwapDirection() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
        
            if (touch.phase == TouchPhase.Began) {
                startTouchPosition = touch.position;
            }
        
            if (touch.phase == TouchPhase.Ended) {
                endTouchPosition = touch.position;
        
                var swipeDistance = Vector2.Distance(startTouchPosition, endTouchPosition);
        
                if (swipeDistance > swipeThreshold) {
                    Vector2 swipeDirection = endTouchPosition - startTouchPosition;
        
                    if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y)) {
                        if (swipeDirection.x > 0) {
                            return 1;
                        }

                        return 2;
                    }
                }
            }
        }

        return 0;
    }
}
