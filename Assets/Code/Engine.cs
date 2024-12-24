using UnityEngine;
using UnityEngine.SceneManagement;


// todo: delete the save

// todo: change the size
// todo: settings page for excel save by button
// todo: check the scroll on all the scenes


public class Engine : MonoBehaviour {

    public static Engine ins;
    public static UI ui;
    public static Controller ctrl;

    public static int pageIdx;

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

    private static void InitGame() {
        
        Screen.orientation = ScreenOrientation.Portrait;

    }

    public void EndGame() {
        GM.Save();
        Input.backButtonLeavesApp = true;
        Application.Quit();
    }

    private void FixedUpdate() {
        CheckUIUpdate();
        
    }

    private static void ExportData() {
        CSVExporter.ExportScoresToCSV();
        CSVExporter.ExportProgressToCSV();
    }

    public static void SaveData() {
        GM.Save();
        ExportData();
    }
    

    public static void Echo(bool b, string s) {
        if (!b) return;
        Debug.Log(s);
    }


    static void CheckUIUpdate() {
        if (ui.updAll) {
            ui.updScoreList = true;
            ui.updAll = false;
        }
    }

    public static void SetScene(string sceneName) {
        // SetPause(true);
        SceneManager.LoadScene(sceneName);
    }
    
    public static void CreateScore() {
        SetScene("ScoreCreate");
    }
    
    public static void ShowScoreList() {
        SetScene("ScoreList");
    }

    public static void CreateRec() {
        SetScene("RecCreate");
    }
    
    public static void ShowProgressPace() {
        SetScene("ProgressPace");
    }
    
    public static void ShowGradePage() {
        SetScene("GradePage");
    }
    
    public static void ShowScalePage() {
        SetScene("ScalePage");
    }
    
}


 
    

