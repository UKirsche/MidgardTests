using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
/// Testet auf Basiseigenschaftswerte von Abenteurern.
/// ACHTUNG: In der Regel ist ein Mensch die Rasse. Falls kein Mensch die Rasse ist:
/// 
/// </summary>
public class AbenteurerBasisEigenschaftenTest {


	//Maximalwerte
	private readonly int _EIGENSCHAFT_MAX=100;
	private readonly int _EIGENSCHAFT_MIN=1;


	//Empfohlene Mindeswerte für Abenteurer

	//Kämpfer
	//Assassine
	private readonly int _AS_GS=61;
	private readonly int _AS_GW=61;

	//Barbar-Nordland
	private readonly int _BN_ST=31;

	//Barbar-Steppe
	private readonly int _BS_ST=31;
	private readonly int _BS_GS=31;

	//Barbar-Wald
	private readonly int _BW_ST=31;
	private readonly int _BW_GS=31;
	private readonly int _BW_GW=31;

	//Ermittler
	private readonly int _ER_GS=31;
	private readonly int _ER_IN=61;

	//Glücksritter
	private readonly int _GL_GS=31;
	private readonly int _GL_GW=61;
	private readonly int _GL_PA=61;

	//Händler
	private readonly int _HAE_GS=31;
	private readonly int _HAE_IN=31;
	private readonly int _HAE_PA=61;

	//Krieger
	private readonly int _KR_ST=61;
	private readonly int _KR_GS=31;

	//Kundschafter
	private readonly int _KU_GS=61;
	private readonly int _KU_IN=61;

	//Seefahrer
	private readonly int _SE_GS=31;
	private readonly int _SE_GW=61;
	private readonly int _SE_IN=31;

	//Söldner-Wald
	private readonly int _SOE_ST=61;
	private readonly int _SOE_GS=31;

	//Spitzbube
	private readonly int _SP_GS=61;
	private readonly int _SP_IN=61;

	//Waldläufer
	private readonly int _WA_GS=31;
	private readonly int _WA_GW=61;
	private readonly int _WA_IN=31;

	//Zauberkundige Kämpfer
	//Barde 
	private readonly int _BA_GS=31;
	private readonly int _BA_IN=61;
	private readonly int _BA_PA=61;

	//Ordenskrieger
	private readonly int _OR_ST=31;
	private readonly int _OR_GS=31;

	//Tiermeister
	private readonly int _TM_GS=31;
	private readonly int _TM_IN=31;
	private readonly int _TM_PA=61;


	//Zauberer
	private readonly int _ZAUBERER_IN=21;

	//Heiler
	private readonly int _HL_GS=31;
	private readonly int _HL_IN=31;

	//Schamane
	private readonly int _SC_ST=31;
	private readonly int _SC_GS=31;
	private readonly int _SC_IN=31;

	//Thaumaturg
	private readonly int _TH_GS=31;
	private readonly int _TH_IN=21;




	//Testcharakter
	private MidgardCharakter _mCharacter;


	public AbenteurerBasisEigenschaftenTest(){
		_mCharacter = new MidgardCharakter ();
	}

	/// <summary>
	/// Testet alle Staekre für die Rasse Mensch.
	/// Betrifft: Barbaren, Krieger, Söldner
	/// </summary>
	[Test]
	public void TesteStaerkeMenschForAllATypen(){
		_mCharacter.Spezies = Races.Mensch;
		var aTypen = Enum.GetValues (typeof(AbenteuerTyp));

		try {
			foreach (AbenteuerTyp aTyp in aTypen) {
				_mCharacter.Archetyp = aTyp;
				int St = CharacterEngine.ComputeBasisSt (this._mCharacter); //Stärke
				switch (_mCharacter.Archetyp) {
				case AbenteuerTyp.As:
				case AbenteuerTyp.Er:
				case AbenteuerTyp.Gl:
				case AbenteuerTyp.Hä:
				case AbenteuerTyp.Ku:
				case AbenteuerTyp.Se:
				case AbenteuerTyp.Sp:
				case AbenteuerTyp.Wa:
					Assert.LessOrEqual (St, this._EIGENSCHAFT_MAX);
					Assert.GreaterOrEqual (St, this._EIGENSCHAFT_MIN);
					break;
				case AbenteuerTyp.BN:
					Assert.GreaterOrEqual (St, this._BN_ST, "Barbar Nordland Stärke zu gering");
					break;
				case AbenteuerTyp.BS:
					Assert.GreaterOrEqual (St, this._BS_ST, "Barbar Steppe Stärke zu gering");
					break;
				case AbenteuerTyp.BW:
					Assert.GreaterOrEqual (St, this._BW_ST, "Barbar Wald Stärke zu gering");
					break;
				case AbenteuerTyp.Kr:
					Assert.GreaterOrEqual (St, this._KR_ST, "Krieger Stärke zu gering");
					break;
				case AbenteuerTyp.Soe:
					Assert.GreaterOrEqual (St, this._SOE_ST, "Söldner Stärke zu gering");
					break;
				case AbenteuerTyp.Sc:
					Assert.GreaterOrEqual (St, this._SC_ST, "Schamane Stärke zu gering");
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

	/// <summary>
	/// Testet Geschicklichkeit für alle AbenteurerTypen für die Rasse Mensch.
	/// Betrifft: Kämpfer - ALLE außer Barbar Nordland (BN)
	/// 		  Zauberer- Heiler, Schamane, Thaumaturg
	/// , Söldner
	/// </summary>
	[Test]
	public void TesteGeschicklichkeitMenschForAllATypen(){
		_mCharacter.Spezies = Races.Mensch;
		var aTypen = Enum.GetValues (typeof(AbenteuerTyp));

		try {
			foreach (AbenteuerTyp aTyp in aTypen) {
				_mCharacter.Archetyp = aTyp;
				int Gs = CharacterEngine.ComputeBasisGs (this._mCharacter); //Geschicklichkeit

				switch (_mCharacter.Archetyp) {
				case AbenteuerTyp.BN:
				case AbenteuerTyp.Be:
				case AbenteuerTyp.Dr:
				case AbenteuerTyp.Hx:
				case AbenteuerTyp.Ma:
				case AbenteuerTyp.PF:
				case AbenteuerTyp.PHa:
				case AbenteuerTyp.PHe:
				case AbenteuerTyp.PK:
				case AbenteuerTyp.PM:
				case AbenteuerTyp.PT:
				case AbenteuerTyp.PW:
					Assert.LessOrEqual (Gs, this._EIGENSCHAFT_MAX);
					Assert.GreaterOrEqual (Gs, this._EIGENSCHAFT_MIN);
					break;
				case AbenteuerTyp.As:
					Assert.GreaterOrEqual (Gs, this._AS_GS, "Assassine Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.BS:
					Assert.GreaterOrEqual (Gs, this._BS_GS, "Barbar Steppe Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.BW:
					Assert.GreaterOrEqual (Gs, this._BW_GS, "Barbar Wald Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Er:
					Assert.GreaterOrEqual (Gs, this._ER_GS, "Ermittler Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Gl:
					Assert.GreaterOrEqual (Gs, this._GL_GS, "Glücksritter Geschicklichkeit zu gering , Gs:" + Gs );
					break;
				case AbenteuerTyp.Hä:
					Assert.GreaterOrEqual (Gs, this._HAE_GS, "Händler Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Kr:
					Assert.GreaterOrEqual (Gs, this._KR_GS, "Krieger Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Ku:
					Assert.GreaterOrEqual (Gs, this._KU_GS, "Kundschafter Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Se:
					Assert.GreaterOrEqual (Gs, this._SE_GS, "Seefahrer Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Soe:
					Assert.GreaterOrEqual (Gs, this._SOE_GS, "Söldner Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Sp:
					Assert.GreaterOrEqual (Gs, this._SP_GS, "Spitzbube Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Wa:
					Assert.GreaterOrEqual (Gs, this._WA_GS, "Waldläufer Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Ba:
					Assert.GreaterOrEqual (Gs, this._BA_GS, "Barde Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Or:
					Assert.GreaterOrEqual (Gs, this._OR_GS, "Ordenskrieger Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Tm:
					Assert.GreaterOrEqual (Gs, this._TM_GS, "Tiermeister Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Hl:
					Assert.GreaterOrEqual (Gs, this._HL_GS, "Heiler Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Sc:
					Assert.GreaterOrEqual (Gs, this._SC_GS, "Schamane Geschicklichkeit zu gering, Gs:" + Gs );
					break;
				case AbenteuerTyp.Th:
					Assert.GreaterOrEqual (Gs, this._TH_GS, "Thaumaturg Geschicklichkeit zu gering, Gs:" + Gs );
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

	/// <summary>
	/// Testet Gewandtheit für alle AbenteurerTypen für die Rasse Mensch.
	/// Betrifft: Kämpfer - Assassine, Barbar Wald (BW), Glücksritter (Gl), Seefahrer (Se), Waldläufer (Wa)
	/// 		  Zauberer, Zauberkundige Kämpfer: KEINER
	/// </summary>
	[Test]
	public void TesteGewandtheitMenschForAllATypen(){
		_mCharacter.Spezies = Races.Mensch;
		var aTypen = Enum.GetValues (typeof(AbenteuerTyp));

		try {
			foreach (AbenteuerTyp aTyp in aTypen) {
				_mCharacter.Archetyp = aTyp;
				int Gw = CharacterEngine.ComputeBasisGw (this._mCharacter); //Geschicklichkeit

				switch (_mCharacter.Archetyp) {
				case AbenteuerTyp.As:
					Assert.GreaterOrEqual (Gw, this._AS_GW, "Assassine Gewandtheit zu gering, Gw:" + Gw );
					break;
				case AbenteuerTyp.BW:
					Assert.GreaterOrEqual (Gw, this._BW_GW, "Barbar Wald Gewandtheit zu gering, Gw:" + Gw );
					break;
				case AbenteuerTyp.Gl:
					Assert.GreaterOrEqual (Gw, this._GL_GW, "Glücksritter Gewandtheit zu gering , Gw:" + Gw );
					break;
				case AbenteuerTyp.Se:
					Assert.GreaterOrEqual (Gw, this._SE_GW, "Seefahrer Gewandtheit zu gering, Gw:" + Gw );
					break;
				case AbenteuerTyp.Wa:
					Assert.GreaterOrEqual (Gw, this._WA_GW, "Waldläufer Gewandtheit zu gering, Gw:" + Gw );
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

	/// <summary>
	/// Testet Intelligenz für alle AbenteurerTypen für die Rasse Mensch.
	/// Betrifft: Kämpfer - Ermittler, HÄndler, Kundschafter, Spitzbube, Waldläufer, Barde, Tiermeister, 
	/// 		  Zauberer- Alle 
	/// </summary>
	[Test]
	public void TesteIntelligenzMenschForAllATypen(){
		_mCharacter.Spezies = Races.Mensch;
		var aTypen = Enum.GetValues (typeof(AbenteuerTyp));

		try {
			foreach (AbenteuerTyp aTyp in aTypen) {
				_mCharacter.Archetyp = aTyp;
				int In = CharacterEngine.ComputeBasisIn (this._mCharacter); //Geschicklichkeit

				switch (_mCharacter.Archetyp) {
				case AbenteuerTyp.Er:
					Assert.GreaterOrEqual (In, this._ER_IN, "Ermittler Intelligenz zu gering, In:" + In );
					break;
				case AbenteuerTyp.Hä:
					Assert.GreaterOrEqual (In, this._HAE_IN, "Händler Intelligenz zu gering, In:" + In );
					break;
				case AbenteuerTyp.Ku:
					Assert.GreaterOrEqual (In, this._KU_IN, "Kundschafter Intelligenz zu gering , In:" + In );
					break;
				case AbenteuerTyp.Sp:
					Assert.GreaterOrEqual (In, this._SP_IN, "Spitzbube Intelligenz zu gering, In:" + In );
					break;
				case AbenteuerTyp.Wa:
					Assert.GreaterOrEqual (In, this._WA_IN, "Waldläufer Intelligenz zu gering, In:" + In );
					break;
				case AbenteuerTyp.Ba:
					Assert.GreaterOrEqual (In, this._BA_IN, "Barde Intelligenz zu gering, In:" + In );
					break;
				case AbenteuerTyp.Tm:
					Assert.GreaterOrEqual (In, this._TM_IN, "Tiermeister Intelligenz zu gering, In:" + In );
					break;
				case AbenteuerTyp.Be:
				case AbenteuerTyp.Dr:
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
					Assert.GreaterOrEqual (In, this._ZAUBERER_IN, "Zauberer Intelligenz " + aTyp.ToString() + " zu gering, In:" + In );
					break;
				case AbenteuerTyp.Hl:
					Assert.GreaterOrEqual (In, this._HL_IN, "Heiler Intelligenz zu gering, In:" + In );
					break;
				case AbenteuerTyp.Sc:
					Assert.GreaterOrEqual (In, this._SC_IN, "Schamane Intelligenz zu gering, In:" + In );
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


	/// <summary>
	/// Testet persönliche Ausstrahlung für alle AbenteurerTypen für die Rasse Mensch.
	/// ACHTUNG: pA hängt ab von Aussehen und Intelligenz, Ermittler würde ich gerne weg lassen
	/// Betrifft: Kämpfer - Glücksritter, Händler
	/// 		  Zauberk. Kämpfer: Barde, Tiermeister
	/// </summary>
	[Test]
	public void TestePAMenschForAllATypen(){
		_mCharacter.Spezies = Races.Mensch;
		var aTypen = Enum.GetValues (typeof(AbenteuerTyp));

		try {
			foreach (AbenteuerTyp aTyp in aTypen) {
				_mCharacter.Archetyp = aTyp;
				CharacterEngine.ComputeBasisIn(this._mCharacter);
				CharacterEngine.ComputeErscheinung(this._mCharacter);
				CharacterEngine.ComputePsychisch (this._mCharacter); //enthält pA!!
				int pA = _mCharacter.pA;

				switch (_mCharacter.Archetyp) {
				case AbenteuerTyp.Hä:
					Assert.GreaterOrEqual (pA, this._HAE_PA, "Händler pA zu gering, pA:" + pA );
					break;
				case AbenteuerTyp.Gl:
					Assert.GreaterOrEqual (pA, this._GL_PA, "Glücksritter pA zu gering , pA:" + pA );
					break;
				case AbenteuerTyp.Ba:
					Assert.GreaterOrEqual (pA, this._BA_PA, "Barde pA zu gering, pA:" + pA );
					break;
				case AbenteuerTyp.Tm:
					Assert.GreaterOrEqual (pA, this._TM_PA, "Tiermeister pA zu gering, pA:" + pA );
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
