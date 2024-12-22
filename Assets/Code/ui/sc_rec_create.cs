using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class sc_rec_create : MonoBehaviour {
    
    public Rec _rec;
    private int _grade;
    private int _quarter;
    private DateTime _dt;
    private string _head;
    private string _code;

    
    public TextMeshProUGUI  tCode;
    public TMP_InputField iComposer;
    public Transform bGrade;
    public Transform bQuarter;
    public Transform trComp;
    public Transform bComp;

    public Button bSave;
    public Button bCancel;
    
    

    void Start() {
        SetGrade(1);
        for (int i = 0; i < bGrade.childCount; i++) {
            var n = i+1;
            bGrade.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate { SetGrade(n); });
        }
        
        SetQuarter(1);
        for (int i = 0; i < bQuarter.childCount; i++) {
            var n = i+1;
            bQuarter.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate { SetQuarter(n); });
        }
        
        bSave.onClick.AddListener(SaveRec);
        bCancel.onClick.AddListener(Engine.ins.ShowProgressPace);

        iComposer.onValueChanged.AddListener(OnComposerInputChanged);
        trComp.gameObject.SetActive(false);
        
        bSave.interactable = false;
        _dt = DateTime.Now;
    }

    private void SetQuarter(int n) {
        _quarter = n;
        for (int i = 0; i < bQuarter.childCount; i++) {
            bQuarter.GetChild(i).GetComponent<Image>().color = Meta.clNotActive;
        }
        bQuarter.GetChild(n-1).GetComponent<Image>().color = Meta.clActive;
    }

    private void OnComposerInputChanged(string arg0) {
        var substr = arg0.ToLower();
        if (substr == "") return;
        
        var filteredChoices = Engine.ctrl.scores
                                    .Where(item => item.Composer.ToLower().StartsWith(substr)) // Ensure unique composers
                                    .ToList(); 
            
        if (filteredChoices.Count > 0) {
            trComp.gameObject.SetActive(true);
            
            for (int i = 0; i < bComp.childCount; i++) {
                bComp.GetChild(i).gameObject.SetActive(false);
            }
            
            var c = filteredChoices.Count > bComp.childCount ? bComp.childCount : filteredChoices.Count;
            
            for (int i = 0; i < c; i++) {
                var n = i;
                bComp.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = 
                                                    filteredChoices[i].Code + 
                                                " " + filteredChoices[i].Composer + 
                                                ": " + filteredChoices[i].Title;
                bComp.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate {
                    SetCompTitle(filteredChoices[n].Code, filteredChoices[n].Composer, filteredChoices[n].Title); });
                bComp.GetChild(i).gameObject.SetActive(true);
            }
        }
    }


    private void SetCompTitle(string cod, string com, string t) {
        iComposer.text = cod + " " + com + ": " + t;
        _head = _dt.ToString("dd-MM-yyyy") + ": " + cod + " " + com + " " + t;
        _code = cod;
        trComp.gameObject.SetActive(false);
    }

    private void SetGrade(int n) {
        _grade = n;
        for (int i = 0; i < bGrade.childCount; i++) {
            bGrade.GetChild(i).GetComponent<Image>().color = Meta.clNotActive;
        }
        bGrade.GetChild(n-1).GetComponent<Image>().color = Meta.clActive;
    }
    
    private void FixedUpdate() {

        bSave.interactable = CheckInput();
        UpdateData();
    }

    private void UpdateData() {
        if (_grade > 0) {

            tCode.text = _head;
            // _n = Logic.GetNextIdByGrade(_grade);
            // tCode.text = Logic.GetCodeByGrade(_grade) + _n.ToString("000");
        }
    }

    private bool CheckInput() {
        return _grade > 0 && iComposer.text != "" && _quarter > 0 && _head != "";
    }
    
    private void SaveRec() {
        if (!Logic.FindRecToday()) {
            _rec = new Rec(_dt);
            _rec.Exercises.Add(new Exercise(_code, _quarter));
            Engine.ctrl.recs.Add(Rec.CreateRec(_rec));

        } else {
            var found = false;

            foreach (var t in Engine.ctrl.recs) {

                if (t.Day.Date == DateTime.Today.Date) {
                    foreach (var t1 in t.Exercises) {
                        var exercise = t1;
                        if (exercise._code == _code) {
                            exercise._quarter += _quarter;
                            found = true;
                        }
                    }
                    if (!found) {
                        t.Exercises.Add(new Exercise(_code, _quarter));

                    }
                }
                
            }

            Engine.ins.SaveData();
            Engine.ins.SetScene("ProgressPace");
        }
    }
    

}
