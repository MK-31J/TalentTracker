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
		writer.WriteLine("Day,Code1,Quarter1");

		// Write data rows
		foreach (var row in Engine.ctrl.recs) {
			writer.WriteLine($"{row.Day},{row.Exercises[0]._code},{row.Exercises[0]._quarter}");
		}
	}
}
