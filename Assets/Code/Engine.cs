using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Linq;
using UnityEditor.U2D.Path.GUIFramework;


// todo: edit score
// todo: rec add
// todo: rec edit
// todo: delete the save
// todo: swap should show filtered information (grade, month)
// todo: filter the rec comp by the level - it is not working now



public class Engine : MonoBehaviour {

    public static Engine ins;
    public static UI ui;
    public static Controller ctrl;

    public GM game;
    // public List<int> stats;


    private void Awake() {
        if (ins == null) {
            ins = this;
            ui = ins.gameObject.GetComponent<UI>();
            ctrl = ins.gameObject.GetComponent<Controller>();
            InitGame();
            DontDestroyOnLoad(gameObject);
        } else {
            DestroyImmediate(gameObject);
        }
    }

    public void InitGame() {
        
        // // json texts
        // // GetLists();
        Screen.orientation = ScreenOrientation.Portrait;
        // ctrl.gameTime = new GameTime(1, 1, 6);
        //
        // StartGame();
        // SetStateWeek(1);

    }

    // public static void SetStateWeek(int i) {
    //     // 0 - init, 1 - first start, 2 - start, 5 - in process, 10 - end
    //     stateWeek = i;
    // }
    //
    // public void StartGame() {
    //     
    //     // if not json
    //     jobs = new List<Job>();
    //     entertainments = new List<Entertainment>();
    //     educations = new List<Education>();
    //
    //     // educations.Add(new Education(Act.Study, "Oxford", new List<int>{1,2,3,4,5}, 9, 6, 3));
    //     jobs.Add(new Job(Act.Work, "Loader", new List<int>{1,2,3,4,6}, 18, 4, 40, 2));
    //     jobs.Add(new Job(Act.Work, "Loader 2", new List<int>{7}, 10, 6, 30, 2));
    //     entertainments.Add(new Entertainment(Act.Rest, "Theater", new List<int>{7}, 21, 2, 25, 25, 50));
    //
    //     // set lists
    //     categories = SetCategories();
    //     activities = Controller.SetActivities();
    //     formats = Controller.SetFormats();
    //     genres = Controller.SetGenres();
    //
    //    
    // }



    public void EndGame() {
        GM.Save();
        Input.backButtonLeavesApp = true;
        Application.Quit();
    }


    void FixedUpdate() {
        CheckUIUpdate();
        
        // Echo(false, Controller.valHeroNoSleepHours.ToString());
        
    }
    
    public void ExportData() {
        CSVExporter.ExportScoresToCSV();
        CSVExporter.ExportProgressToCSV();
    }

    public void SaveData() {
        GM.Save();
        ExportData();
    }
    

    public static void Echo(bool b, string s) {
        if (!b) return;
        Debug.Log(s);
    }

 
    void CheckUIUpdate() {
        if (ui.updAll) {
            ui.updScoreList = true;
            ui.updAll = false;
        }
    }

    public void SetScene(string sceneName) {
        // SetPause(true);
        SceneManager.LoadScene(sceneName);
    }
    
    public void CreateScore() {
        SetScene("ScoreCreate");
    }
    
    public void ShowScoreList() {
        SetScene("ScoreList");
    }

    public void CreateRec() {
        SetScene("RecCreate");
    }
    
    public void ShowProgressPace() {
        SetScene("ProgressPace");
    }
    
    public void ShowGradePage() {
        SetScene("GradePage");
    }
    
    public void ShowScalePage() {
        SetScene("ScalePage");
    }
    
}


 
    

