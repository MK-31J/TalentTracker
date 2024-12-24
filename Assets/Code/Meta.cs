
using UnityEngine;

public class Meta {
	
	public static Color clGrade1 = new Color32(200, 231, 200, 80);
	public static Color clGrade2 = new Color32(231, 231, 200, 80);
	public static Color clGrade3 = new Color32(231, 200, 200, 80);
	public static Color clGrade4 = new Color32(231, 200, 231, 80);
	
	public static Color clActive = new Color32(120, 241, 231, 80);
	public static Color clNotActive = new Color32(231, 231, 231, 231);
	
	public static Color clHighlight = new Color32(180, 230, 230, 241);
	
	public static readonly Color32[] clScoreSts = {
		new(231, 231, 231, 231),
		new(120, 231, 231, 231),
		new(70, 70, 70, 231)
	};

	public static readonly Color32[] clScoreStyle = {
		new(231, 231, 231, 231),
		new(255, 255, 160, 231),
		new(180, 180, 255, 231),
		new(255, 180, 180, 231)
	};
}
