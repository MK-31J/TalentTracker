using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVExporter {
	
	public static void ExportScoresToCSV() {
		string fileName = "ScoresDataExported_" + DateTime.Today.ToString("yy_MM_dd") + ".csv";
		var filePath = Path.Combine(Application.persistentDataPath, fileName);
		using var writer = new StreamWriter(filePath);
		
		// Write headers
		writer.WriteLine("Grade,N,Code,Composer,Title,Style,StartTime,EndTime");

		// Write data rows
		foreach (var row in Engine.ctrl.scores) {
			writer.WriteLine($"{row.Grade},{row.N},{row.Code},{row.Composer},{row.Title},{row.Style},{row.StartTime},{row.EndTime}");
		}
	}
	
	// todo: loop the exercise
	public static void ExportProgressToCSV() {
		string fileName = "PianoDataExported_" + DateTime.Today.ToString("yy_MM_dd") + ".csv";
		var filePath = Path.Combine(Application.persistentDataPath, fileName);
		using var writer = new StreamWriter(filePath);
		
		// Write headers
		writer.WriteLine("Day,Code1,Quarter1,Code2,Quarter2,Code3,Quarter3,Code4,Quarter4,Code5,Quarter5,Code6,Quarter6,Code7,Quarter7");

		// Write data rows
		foreach (var row in Engine.ctrl.recs) {
			var str = $"{row.Day:dd.MM.yyyy}";
			foreach (var exercise in row.Exercises) {
				str += $",{exercise._code},{exercise._quarter}";
			}
			writer.WriteLine(str);
		}
	}
}
