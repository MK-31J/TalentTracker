using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class sc_score_create : MonoBehaviour {
    
    public Score _score;
    private int _grade;
    private int _style;
    private int _n;
    
    public TextMeshProUGUI  tCode;
    public TMP_InputField iComposer;
    public TMP_InputField iTitle;
    public Transform bGrade;
    public Transform bStyle;
    public Transform trComp;
    public Transform trTitle;
    public Transform bComp;
    public Transform bTitle;
    public Button bSave;
    public Button bCancel;
    

    void Start() {
        SetGrade(1);
        for (int i = 0; i < bGrade.childCount; i++) {
            var n = i+1;
            bGrade.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate { SetGrade(n); });
        }

        SetStyle(0);
        for (int i = 0; i < bStyle.childCount; i++) {
            var n = i;
            bStyle.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate { SetStyle(n); });
        }
        
        bSave.onClick.AddListener(SaveScore);
        bCancel.onClick.AddListener(CancelCreate);

        iComposer.onValueChanged.AddListener(OnComposerInputChanged);
        iTitle.onValueChanged.AddListener(OnTitleInputChanged);
            
        trComp.gameObject.SetActive(false);
        trTitle.gameObject.SetActive(false);
        
        bSave.interactable = false;

    }



    private void OnTitleInputChanged(string arg0) {

        var substr = arg0.ToLower();
        if (substr == "") return;
        
        if (substr.Length > 2) {
            trTitle.gameObject.SetActive(false);
            return;
        }
        
        var filteredChoices = Engine.ctrl.scores
                                    .Where(item => item.Title.ToLower().StartsWith(substr))
                                    .DistinctBy(item => item.Title)                   // Ensure unique composers
                                    .ToList(); 
            
        if (filteredChoices.Count > 0) {
            trTitle.gameObject.SetActive(true);
            
            for (var i = 0; i < bTitle.childCount; i++) {
                bTitle.GetChild(i).gameObject.SetActive(false);
            }

            var c = filteredChoices.Count > bTitle.childCount ? bTitle.childCount : filteredChoices.Count;
            
            for (var i = 0; i < c; i++) {
                var n = i;
                bTitle.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = filteredChoices[i].Title;
                bTitle.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate {
                                                    SetTitle(filteredChoices[n].Title); });
                bTitle.GetChild(i).gameObject.SetActive(true);
            }
        }
    }



    private void OnComposerInputChanged(string arg0) {
        var substr = arg0.ToLower();
        if (substr == "") return;
        
        if (substr.Length > 2) {
            trComp.gameObject.SetActive(false);
            return;
        }
        
        var filteredChoices = Engine.ctrl.scores
                                    .Where(item => item.Composer.ToLower().StartsWith(substr))
                                    .DistinctBy(item => item.Composer)                   // Ensure unique composers
                                    .ToList(); 
            
        if (filteredChoices.Count > 0) {
            trComp.gameObject.SetActive(true);
            
            for (var i = 0; i < bComp.childCount; i++) {
                bComp.GetChild(i).gameObject.SetActive(false);
            }

            var c = filteredChoices.Count > bComp.childCount ? bComp.childCount : filteredChoices.Count;
            
            for (var i = 0; i < c; i++) {
                var n = i;
                bComp.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = filteredChoices[i].Composer;
                bComp.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate {
                                                    SetComp(filteredChoices[n].Composer); });
                bComp.GetChild(i).gameObject.SetActive(true);
            }
        }

    }

    private void SetTitle(string t) {
        iTitle.text = t;
        trTitle.gameObject.SetActive(false);
    }
    
    private void SetComp(string c) {
        iComposer.text = c;
        trComp.gameObject.SetActive(false);
    }

    private void SetGrade(int n) {
        _grade = n;
        for (int i = 0; i < bGrade.childCount; i++) {
            bGrade.GetChild(i).GetComponent<Image>().color = Color.white;
        }
        bGrade.GetChild(n-1).GetComponent<Image>().color = Color.green;
    }
    
    private void SetStyle(int n) {
        _style = n;
        for (int i = 0; i < bStyle.childCount; i++) {
            bStyle.GetChild(i).GetComponent<Image>().color = Color.white;
        }
        bStyle.GetChild(n).GetComponent<Image>().color = Color.green;
    }


    private void FixedUpdate() {

        bSave.interactable = CheckInput();
        UpdateData();
    }

    private void UpdateData() {
        if (_grade > 0) {
            _n = Logic.GetNextIdByGrade(_grade);
            tCode.text = Logic.GetCodeByGrade(_grade) + _n.ToString("000");
        }
    }

    private bool CheckInput() {
        return _grade > 0 && iComposer.text != "" && iTitle.text != "";
    }
    
    private void SaveScore() {
        _score = new Score(_n, _grade, iComposer.text, iTitle.text, _style);
        Engine.ctrl.scores.Add(Score.CreateScore(_score));
        GM.Save();
        Engine.ins.SetScene("GradeList");
    }
    
    private void CancelCreate() {
        Engine.ins.SetScene("GradeList");
    }
}
