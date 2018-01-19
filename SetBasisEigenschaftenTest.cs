using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
/// Testet die Werte der Basiseigenschaften: St, Gs, Gw, Ko, In, Zt für die verschiedenen Rassen
/// </summary>
[TestFixture]
public class SetBasisEigenschaftenTest
{
	//Eigenschaftsbeschränkungen für Rassen
	private readonly int _EIGENSCHAFT_MAX = 100;
	private readonly int _EIGENSCHAFT_MIN = 1;

	private readonly int _ST_MAX_ELF = 90;
	private readonly int _ST_MAX_GNOM = 60;
	private readonly int _ST_MAX_HALBLING = 80;
	private readonly int _ST_MIN_ZWERG = 61;

	private readonly int _GS_MIN_GNOM = 81;
	private readonly int _GS_MIN_HALBLING = 61;

	private readonly int _GW_MIN_ELF = 81;
	private readonly int _GW_MIN_GNOM = 81;
	private readonly int _GW_MIN_HALBLING = 91;
	private readonly int _GW_MAX_ZWERG = 80;

	private readonly int _KO_MIN_ELF = 61;
	private readonly int _KO_MIN_GNOM = 31;
	private readonly int _KO_MIN_ZWERG = 61;

	private readonly int _IN_MIN_ELF = 61;

	private readonly int _ZT_MIN_ELF = 61;
	private MidgardCharakter _mCharacter;

	public SetBasisEigenschaftenTest(){

		//Debug.Log("hier");
		_mCharacter = new MidgardCharakter ();
	}

	/// <summary>
	/// Teste die Stärke für alle Rassen
	/// </summary>
	[Test]
	public void TestStaerkeForAllRaces(){
		//Transformiere Enum nach Value
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				_mCharacter.Spezies = race;
				int St = CharacterEngine.ComputeBasisSt (this._mCharacter);
				switch (_mCharacter.Spezies) {
				case Races.Mensch:
					Assert.LessOrEqual (St, this._EIGENSCHAFT_MAX);
					Assert.GreaterOrEqual (St, this._EIGENSCHAFT_MIN);
					break;
				case Races.Elf:
					Assert.LessOrEqual (St, this._ST_MAX_ELF, "Elfenstärke zu hoch");
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
					Assert.LessOrEqual (St, this._ST_MAX_GNOM, "Gnomenstärke zu hoch");
					break;
				case Races.Halbling:
					Assert.LessOrEqual (St, this._ST_MAX_HALBLING, "Halblingstärke zu hoch");
					break;
				case Races.Zwerg:
					Assert.GreaterOrEqual (St, this._ST_MIN_ZWERG, "Zwergenstärke zu gering");
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
	/// Teste die Geschicklichkeit für alle Rassen
	/// </summary>
	[Test]
	public void TestGeschicklichkeitForAllRaces(){
		//Transformiere Enum nach Value
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				_mCharacter.Spezies = race;
				int Gs = CharacterEngine.ComputeBasisGs (this._mCharacter);
				switch (_mCharacter.Spezies) {
				case Races.Mensch:
				case Races.Elf:
				case Races.Zwerg:
					Assert.LessOrEqual (Gs, this._EIGENSCHAFT_MAX);
					Assert.GreaterOrEqual (Gs, this._EIGENSCHAFT_MIN);
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
					Assert.GreaterOrEqual (Gs, this._GS_MIN_GNOM, "Gnomengeschick zu gering");
					break;
				case Races.Halbling:
					Assert.GreaterOrEqual (Gs, this._GS_MIN_HALBLING, "Halblingsgeschick zu gering");
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
	/// Teste die Gewandtheit für alle Rassen
	/// </summary>
	[Test]
	public void TestGewandtheitForAllRaces(){
		//Transformiere Enum nach Value
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				_mCharacter.Spezies = race;
				int Gw = CharacterEngine.ComputeBasisGw (this._mCharacter);
				switch (_mCharacter.Spezies) {
				case Races.Mensch:
					Assert.LessOrEqual (Gw, this._EIGENSCHAFT_MAX);
					Assert.GreaterOrEqual (Gw, this._EIGENSCHAFT_MIN);
					break;
				case Races.Elf:
					Assert.GreaterOrEqual (Gw, this._GW_MIN_ELF, "Elfengewandtheit zu niedrig");
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
					Assert.GreaterOrEqual (Gw, this._GW_MIN_GNOM, "Gnomgewandtheit zu niedrig");
					break;
				case Races.Halbling:
					Assert.GreaterOrEqual (Gw, this._GW_MIN_HALBLING, "Halblingsgewandtheit zu niedrig");
					break;
				case Races.Zwerg:
					Assert.LessOrEqual (Gw, this._GW_MAX_ZWERG, "Zwergengewandheit zu hoch");
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

	///<summary>
	/// Teste die Konstitution für alle Rassen
	/// </summary>
	[Test]
	public void TestKonstitutionForAllRaces(){
		//Transformiere Enum nach Value
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				_mCharacter.Spezies = race;
				int Ko = CharacterEngine.ComputeBasisKo (this._mCharacter);
				switch (_mCharacter.Spezies) {
				case Races.Mensch:
				case Races.Halbling:
					Assert.LessOrEqual (Ko, this._EIGENSCHAFT_MAX);
					Assert.GreaterOrEqual (Ko, this._EIGENSCHAFT_MIN);
					break;
				case Races.Elf:
					Assert.GreaterOrEqual (Ko, this._KO_MIN_ELF, "Elfenkonstitution zu gering");
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
					Assert.GreaterOrEqual (Ko, this._KO_MIN_GNOM, "Gnomenkonstitution zu gering");
					break;
				case Races.Zwerg:
					Assert.GreaterOrEqual (Ko, this._KO_MIN_ZWERG, "Zwergenkonstitution zu gering");
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
	/// Testet In und Zt für Elfen
	/// </summary>
	[Test]
	public void TestIntelligenzZaubertalentElf(){

		this._mCharacter.Spezies = Races.Elf;

		int In = CharacterEngine.ComputeBasisIn (this._mCharacter);
		Assert.GreaterOrEqual (In, this._IN_MIN_ELF, "Elfenintelligenz zu gering");

		int Zt = CharacterEngine.ComputeBasisZt (this._mCharacter);
		Assert.GreaterOrEqual (In, this._ZT_MIN_ELF, "Elfentzaubertalent zu gering");

	}
}

