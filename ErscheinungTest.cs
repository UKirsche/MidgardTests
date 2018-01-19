using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
/// Erscheinung test. Beinhaltet folgende Komponenten:
/// a. Bewegungsweite: Elfen wie Menschen, niedriger für Gnome, Halbinge und Zwerge
/// b. Körpergröße bei Menschen für Mann und Frau, bei Elfen, Gnomen, Zwerge, Halblingen keine Geschlechtsunterscheidung
/// c. Gewicht, s.o.
/// </summary>
public class ErscheinungTest {

	private readonly int _MAX_B = 28;
	private readonly int _MIN_B = 20;

	private readonly int _MAX_B_GNOME = 14;
	private readonly int _MIN_B_GNOME = 10;

	private readonly int _MAX_B_HALBLING = 14;
	private readonly int _MIN_B_HALBLING = 10;

	private readonly int _MAX_B_ZWERG = 21;
	private readonly int _MIN_B_ZWERG = 15;

	private readonly int _MAX_GROESSE_MANN = 200;
	private readonly int _MIN_GROESSE_MANN = 150;

	private readonly int _MAX_GROESSE_FRAU =190;
	private readonly int _MIN_GROESSE_FRAU =140;

	private readonly int _MAX_GROESSE_ELF = 182;
	private readonly int _MIN_GROESSE_ELF = 162;

	private readonly int _MAX_GROESSE_GNOM = 102;
	private readonly int _MIN_GROESSE_GNOM = 91;

	private readonly int _MAX_GROESSE_HALBLING = 120;
	private readonly int _MIN_GROESSE_HALBLING = 102;

	private readonly int _MAX_GROESSE_ZWERG = 146;
	private readonly int _MIN_GROESSE_ZWERG = 137;


	private readonly int _MAX_GEWICHT_MANN = 114;
	private readonly int _MIN_GEWICHT_MANN = 34;

	private readonly int _MAX_GEWICHT_FRAU =100;
	private readonly int _MIN_GEWICHT_FRAU =20;

	private readonly int _MAX_GEWICHT_ELF = 88;
	private readonly int _MIN_GEWICHT_ELF = 38;

	private readonly int _MAX_GEWICHT_GNOM = 36;
	private readonly int _MIN_GEWICHT_GNOM = 4;

	private readonly int _MAX_GEWICHT_HALBLING = 62;
	private readonly int _MIN_GEWICHT_HALBLING = 18;

	private readonly int _MAX_GEWICHT_ZWERG = 90;
	private readonly int _MIN_GEWICHT_ZWERG = 57;

	private readonly int _MAX_AU=100;
	private readonly int _MIN_AU=1;

	private readonly int _MIN_AU_ELF=81;

	private readonly int _MAX_AU_GNOM=80;
	private readonly int _MAX_AU_ZWERG=80;


	private MidgardCharakter mCharacter;

	/// <summary>
	/// Initializes a new instance of the <see cref="ErscheinungTest"/> class.
	/// </summary>
	public ErscheinungTest(){
		mCharacter = new MidgardCharakter ();
	}


	/// <summary>
	/// Bewegungsweite bei 
	/// Menschen: 4W3+6
	/// Gnomen: 2W3+8
	/// Halblinge: 2W3+8
	/// Zwerge: 3W3+12;
	/// </summary>
	[Test]
	public void TestBewegungsweite()
	{
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				mCharacter.Spezies = race;
				CharacterEngine.ComputeErscheinung (this.mCharacter);
				switch (mCharacter.Spezies) {
				case Races.Mensch:
					Assert.GreaterOrEqual(mCharacter.B, _MIN_B,"Mensch oder Elf zu langsam");
					break;
				case Races.Elf:
					Assert.LessOrEqual(mCharacter.B, _MAX_B, "Mensch oder elf zu schnell");
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
				case Races.Halbling:
					Assert.GreaterOrEqual(mCharacter.B, _MIN_B_GNOME,"Gnome oder Halbling zu langsam");
					Assert.LessOrEqual(mCharacter.B, _MAX_B_GNOME, "Gnome oder Halbling zu schnell");
					break;
				case Races.Zwerg:
					Assert.GreaterOrEqual(mCharacter.B, _MIN_B_ZWERG, "Zwerg zu langsam");
					Assert.LessOrEqual(mCharacter.B, _MAX_B_ZWERG, "Zwerg zu schnell");
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

	/// <summary>
	/// Tests the Körpergröße
	/// Maximal- und Minimalwerte sind oben notiert
	/// </summary>
	[Test]
	public void TestGröße()
	{
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				mCharacter.Spezies = race;
				CharacterEngine.ComputeBasisSt(mCharacter);
				CharacterEngine.ComputeErscheinung (this.mCharacter);
				switch (mCharacter.Spezies) {
				case Races.Mensch:
					if(mCharacter.Sex == Geschlecht.Mann){
						Assert.GreaterOrEqual(mCharacter.Groesse, _MIN_GROESSE_MANN, "Mann zu klein!");
						Assert.LessOrEqual(mCharacter.Groesse, _MAX_GROESSE_MANN, "Mann zu groß!");

					} else {
						Assert.GreaterOrEqual(mCharacter.Groesse, _MIN_GROESSE_FRAU, "Frau zu klein!");
						Assert.LessOrEqual(mCharacter.Groesse, _MAX_GROESSE_FRAU, "Frau zu groß!");

					}
					break;
				case Races.Elf:
					Assert.GreaterOrEqual(mCharacter.Groesse, _MIN_GROESSE_ELF,"Elf zu klein");
					Assert.LessOrEqual(mCharacter.Groesse, _MAX_GROESSE_ELF, "Elf zu groß");
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
					Assert.GreaterOrEqual(mCharacter.Groesse, _MIN_GROESSE_GNOM,"Gnom zu klein");
					Assert.LessOrEqual(mCharacter.Groesse, _MAX_GROESSE_GNOM, "Gnom zu groß");
					break;
				case Races.Halbling:
					Assert.GreaterOrEqual(mCharacter.Groesse, _MIN_GROESSE_HALBLING,"Halbling zu klein");
					Assert.LessOrEqual(mCharacter.Groesse, _MAX_GROESSE_HALBLING, "Halbling zu groß");
					break;
				case Races.Zwerg:
					Assert.GreaterOrEqual(mCharacter.Groesse, _MIN_GROESSE_ZWERG,"Zwerg zu klein: " );
					Assert.LessOrEqual(mCharacter.Groesse, _MAX_GROESSE_ZWERG, "Zwerg zu groß");
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


	/// <summary>
	/// Tests the Gewicht
	/// Maximal- und Minimalwerte sind oben notiert
	/// </summary>
	[Test]
	public void TestGewicht()
	{
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				mCharacter.Spezies = race;
				CharacterEngine.ComputeBasisSt(mCharacter);
				CharacterEngine.ComputeErscheinung (this.mCharacter);
				switch (mCharacter.Spezies) {
				case Races.Mensch:
					if(mCharacter.Sex == Geschlecht.Mann){
						Assert.GreaterOrEqual(mCharacter.Gewicht, _MIN_GEWICHT_MANN, "Mann zu dünn!");
						Assert.LessOrEqual(mCharacter.Gewicht, _MAX_GEWICHT_MANN, "Mann zu dick!");

					} else {
						Assert.GreaterOrEqual(mCharacter.Gewicht, _MIN_GEWICHT_FRAU, "Frau zu dünn!");
						Assert.LessOrEqual(mCharacter.Gewicht, _MAX_GEWICHT_FRAU, "Frau zu dick!");

					}
					break;
				case Races.Elf:
					Assert.GreaterOrEqual(mCharacter.Gewicht, _MIN_GEWICHT_ELF,"Elf zu dünn");
					Assert.LessOrEqual(mCharacter.Gewicht, _MAX_GEWICHT_ELF, "Elf zu dick");
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
					Assert.GreaterOrEqual(mCharacter.Gewicht, _MIN_GEWICHT_GNOM,"Gnom zu dünn");
					Assert.LessOrEqual(mCharacter.Gewicht, _MAX_GEWICHT_GNOM, "Gnom zu dick");
					break;
				case Races.Halbling:
					Assert.GreaterOrEqual(mCharacter.Gewicht, _MIN_GEWICHT_HALBLING,"Halbling zu dünn");
					Assert.LessOrEqual(mCharacter.Gewicht, _MAX_GEWICHT_HALBLING, "Halbling zu dick");
					break;
				case Races.Zwerg:
					Assert.GreaterOrEqual(mCharacter.Gewicht, _MIN_GEWICHT_ZWERG,"Zwerg zu dünn: " );
					Assert.LessOrEqual(mCharacter.Gewicht, _MAX_GEWICHT_ZWERG, "Zwerg zu dick");
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

	/// <summary>
	/// Tests the Aussehen of the Character.
	/// </summary>
	[Test]
	public void TestAussehen()
	{
		var races = Enum.GetValues (typeof(Races));
		try {
			foreach (Races race in races) {
				mCharacter.Spezies = race;
				CharacterEngine.ComputeErscheinung (this.mCharacter);
				switch (mCharacter.Spezies) {
				case Races.Mensch:
				case Races.Halbling:
					Assert.LessOrEqual(mCharacter.Aussehen, _MAX_AU,"Mensch zu schön");
					break;
				case Races.Elf:
					Assert.GreaterOrEqual(mCharacter.Aussehen, _MIN_AU_ELF, "Elf zu hässlich");
					break;
				case Races.Berggnom:
				case Races.Waldgnom:
				case Races.Zwerg:
					Assert.LessOrEqual(mCharacter.Aussehen, _MAX_AU_GNOM, "Gnom oder Zwerg zu hübsch");
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
}
