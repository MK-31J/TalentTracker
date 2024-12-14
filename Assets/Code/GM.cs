using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[Serializable]
public class GM {
    
    private List<Score> _scores;
    
    public GM(List<Score> scores) {
        _scores = scores;
    }
    
    
    public static void Save() {

        GM game = new GM(Engine.ctrl.scores);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/ScoresList.gd");
        bf.Serialize(file, game);
        file.Close();
    }
    
    public static void Load() {
        if (File.Exists(Application.persistentDataPath + "/ScoresList.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ScoresList.gd", FileMode.Open);
            var game = (GM)bf.Deserialize(file);
            file.Close();
            Engine.ctrl.scores = game._scores;
        }
    }
    
}
