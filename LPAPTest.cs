using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class LPAPTest {

	private readonly int _MIN_LP_MENSCH=5;
	private readonly int _MIN_LP_ELF=11;
	private readonly int _MIN_LP_ZWERG=11;
	private readonly int _MIN_LP_GNOM=4;
	private readonly int _MIN_LP_HALBLING=3;
	private readonly int _MAX_LP_MENSCH=20;
	private readonly int _MAX_LP_ELF=21;
	private readonly int _MAX_LP_ZWERG=21;
	private readonly int _MAX_LP_GNOM=16;
	private readonly int _MAX_LP_HALBLING=18;

	private readonly int _MIN_AP_KÄMPFER_I =4;
	private readonly int _MIN_AP_KÄMPFER_II =4;
	private readonly int _MIN_AP_ZAUBERER =4;

	private readonly int _MAX_AP_KÄMPFER_I =18;
	private readonly int _MAX_AP_KÄMPFER_II =17;
	private readonly int _MAX_AP_ZAUBERER =16;



	private MidgardCharakter mCharacter;

	/// <summary>
	/// Initializes a new instance of the <see cref="LPAPTest"/> class.
	/// </summary>
	public LPAPTest(){
		this.mCharacter = new MidgardCharakter ();
	}

	/*
	 * Hier können die Min-und Max-Werte empirisch ermittelt werden
	[Test]
	public void TestLPsHalbling1000Times(){
		this.mCharacter.Spezies = Races.Halbling;
		int minVal = 0, maxVal = 0;
		for (int i = 0; i < 2000; i++) {
			CharacterEngine.ComputeBasisKo (this.mCharacter);
			CharacterEngine.ComputeAPLP(this.mCharacter);

			if (i == 0) {
				minVal = this.mCharacter.LP;
				maxVal = minVal;
			} else {
				minVal = Mathf.Min (minVal, this.mCharacter.LP);
				maxVal = Mathf.Max (maxVal, this.mCharacter.LP);
			}

		}
		Debug.Log ("Min LP Elf:" + minVal + " und Max LP Elf:" + maxVal);
	}
	*/

	[Test]
	public void TestLPsForAllRaces()
	{
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				mCharacter.Spezies = race;
				CharacterEngine.ComputeBasisKo (this.mCharacter);
				CharacterEngine.ComputeAPLP(this.mCharacter);
				
				switch (mCharacter.Spezies) {
				case Races.Mensch:
					Assert.GreaterOrEqual(mCharacter.LP, _MIN_LP_MENSCH,"Mensch zu wenig LP");
					Assert.LessOrEqual(mCharacter.LP, _MAX_LP_MENSCH,"Mensch zu viel LP");
					break;
				case Races.Elf:
					Assert.GreaterOrEqual(mCharacter.LP, _MIN_LP_ELF,"Elf zu wenig LP");
					Assert.LessOrEqual(mCharacter.LP, _MAX_LP_ELF,"Elf zu viel LP");
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
					Assert.GreaterOrEqual(mCharacter.LP, _MIN_LP_GNOM,"Gnom zu wenig LP");
					Assert.LessOrEqual(mCharacter.LP, _MAX_LP_GNOM,"Gnom zu viel LP");
					break;
				case Races.Halbling:
					Assert.GreaterOrEqual(mCharacter.LP, _MIN_LP_HALBLING,"Halbling zu wenig LP");
					Assert.LessOrEqual(mCharacter.LP, _MAX_LP_HALBLING, "Halbling zu viel LP");
					break;
				case Races.Zwerg:
					Assert.GreaterOrEqual(mCharacter.LP, _MIN_LP_ZWERG, "Zwerg zu wenig LP");
					Assert.LessOrEqual(mCharacter.LP, _MAX_LP_ZWERG, "Zwerg zu viel LP");
					break;
				default:
					break;
				}
			}
		} catch(AssertionException aEx){
			Debug.Log (aEx.ToString ());
			Assert.Fail ();
		}
	}


	[Test]
	public void TestAPsForAllATypen(){
		mCharacter.Spezies = Races.Mensch; //Rasse spielt keine Rolle bei Max- und Minwerten
		var aTypen = Enum.GetValues (typeof(AbenteuerTyp));
		try {
			foreach (AbenteuerTyp aTyp in aTypen) {
				//Debug.Log(aTyp);
				this.mCharacter.Archetyp = aTyp;
				CharacterEngine.ComputeBasisSt (this.mCharacter); //Stärke
				CharacterEngine.ComputeBasisKo (this.mCharacter); //Konstitution -> für AusB
				CharacterEngine.ComputeAbgeleiteteEigenschaften(this.mCharacter);
				CharacterEngine.ComputeAPLP(this.mCharacter);

				switch (this.mCharacter.Archetyp) {
				case AbenteuerTyp.BN:
				case AbenteuerTyp.BS:
				case AbenteuerTyp.BW:
				case AbenteuerTyp.Kr:
				case AbenteuerTyp.Soe:
					Assert.GreaterOrEqual (mCharacter.AP, this._MIN_AP_KÄMPFER_I, "Kä I zu wenig AP " + mCharacter.AP);
					Assert.LessOrEqual (mCharacter.AP, this._MAX_AP_KÄMPFER_I, "Kä I zu viel AP "+ mCharacter.AP);
					break;
				case AbenteuerTyp.As:
				case AbenteuerTyp.Er:
				case AbenteuerTyp.Gl:
				case AbenteuerTyp.Hä:
				case AbenteuerTyp.Ku:
				case AbenteuerTyp.Se:
				case AbenteuerTyp.Sp:
				case AbenteuerTyp.Sc:
				case AbenteuerTyp.Ba:
				case AbenteuerTyp.Or:
				case AbenteuerTyp.Tm:
					Assert.GreaterOrEqual (mCharacter.AP, this._MIN_AP_KÄMPFER_II, "Kä II zu wenig AP "+ mCharacter.AP);
					Assert.LessOrEqual (mCharacter.AP, this._MAX_AP_KÄMPFER_II, "Kä II zu viel AP "+ mCharacter.AP);
					break;
				case AbenteuerTyp.Be:
				case AbenteuerTyp.Dr:
				case AbenteuerTyp.Hl:
				case AbenteuerTyp.Hx:
				case AbenteuerTyp.Ma:
				case AbenteuerTyp.PF:
				case AbenteuerTyp.PHa:
				case AbenteuerTyp.PHe:
				case AbenteuerTyp.PK:
				case AbenteuerTyp.PM:
				case AbenteuerTyp.PT:
				case AbenteuerTyp.PW:
				case AbenteuerTyp.Th:
					Assert.GreaterOrEqual (mCharacter.AP, this._MIN_AP_ZAUBERER, "Zauberer zu wenig AP "+ mCharacter.AP);
					Assert.LessOrEqual (mCharacter.AP, this._MAX_AP_ZAUBERER, "Zauberer zu viel AP "+ mCharacter.AP);
					break;
				default:
					break;
				}
			}
		} catch (AssertionException asEx) {
			Debug.Log (asEx.ToString ());
			Assert.Fail ();
		}
	}
}
