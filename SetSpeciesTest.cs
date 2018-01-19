using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
/// Set species test. Tests um zu sehen, ob richtige Charakterklassen für die gewählten Rassen auswählbar sind
/// Es gibt folgende Species
/// 	* Mensch
/// 	* Elf
/// 	* Gnome (Berg- oder Wald)
/// 	* Halbling
/// 	* Zwerg
/// 
/// Dazu sind folgende Abenteurertypen verfügbar
/// Kämpfer:
/// 	* Assassine (AS)
/// 	* Barbar, Norland (BN)
/// 	* Barbar, Steppe (BS)
/// 	* Barbar, Waldland (BW)
/// 	* Ermittler (ER)
/// 	* Glücksritter (Gl)
/// 	* Händler (Hä)
/// 	* Krieger (Kr)
/// 	* Kundschafter (Ku)
/// 	* Seefahrer (Se)
/// 	* Söldner (Sö)
/// 	* Spitzbube (Sp)
/// 	* Waldläufer (Wa)
/// 
/// Zauberku	ndige Kämpfer
/// 	* Barde (Ba)
/// 	* Ordenskrieger (Or)
/// 	* Tiermeister (Tm)
/// 
/// Zauberer:
/// 	* Beschwörer (Be) hier nur angzeigt
/// 	* Druide (Dr)
/// 	* Heiler (Hl)
/// 	* Hexer (Hx)
/// 	* Magier (Ma)
/// 	* Priester, Fruchbarkeit (PF)
/// 	* Priester, Handel/Handwerk (PHa)
/// 	* Priester, Herrschaft (PHe)
/// 	* Priester, Krieg (Pk)
/// 	* Priester, Meer (PM)
/// 	* Priester, Tod (PT)
/// 	* Priester, Weisheit (PW)
/// 	* Schamance (Sc)
/// 	* Thaumaturg
/// </summary>
[TestFixture]
public class SetSpeciesTest
{
	private readonly int _ANZAHLRASSEN;
	//
	private readonly int _ANZAHL_ABENTEUERERTYPEN_PRO_MENSCH; 
	private readonly int _ANZAHL_ABENTEUERERTYPEN_PRO_ELF;	 
	private readonly int _ANZAHL_ABENTEUERERTYPEN_PRO_BERGGNOM;
	private readonly int _ANZAHL_ABENTEUERERTYPEN_PRO_WALDGNOM;
	private readonly int _ANZAHL_ABENTEUERERTYPEN_PRO_HALBLING;
	private readonly int _ANZAHL_ABENTEUERERTYPEN_PRO_ZWERG;

	private MidgardCharakter _mCharacter;

	public SetSpeciesTest(){
		_mCharacter = new MidgardCharakter ();
		this._ANZAHLRASSEN = 6;
		this._ANZAHL_ABENTEUERERTYPEN_PRO_MENSCH = 30;
		this._ANZAHL_ABENTEUERERTYPEN_PRO_ELF = 8;
		this._ANZAHL_ABENTEUERERTYPEN_PRO_BERGGNOM = 9;
		this._ANZAHL_ABENTEUERERTYPEN_PRO_WALDGNOM = this._ANZAHL_ABENTEUERERTYPEN_PRO_BERGGNOM;
		this._ANZAHL_ABENTEUERERTYPEN_PRO_HALBLING = 7;
		this._ANZAHL_ABENTEUERERTYPEN_PRO_ZWERG = 9;
	}

	/// <summary>
	/// Gets the number rassen test. 
	/// </summary>
	[Test]
	public void GetNumberRassenTest(){
		Rassen midgardRassen = MidgardResourceReader.GetMidgardResource<Rassen> (MidgardResourceReader.MidgardRassen);
		Assert.AreEqual (this._ANZAHLRASSEN, midgardRassen.rassenListe.Count);
	}


	[Test]
	/// <summary>
	/// Test Rasse Mensch. Ermöglicht 30 Abenteurertypen. 
	/// Test auf  enthaltenen Assassinen, Barbar und Ordenskrieger
	/// </summary>
	public void SetSpeciesMenschTest ()
	{
		_mCharacter.Spezies = Races.Mensch;
		int raceId = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypen = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceId);
		Assert.AreEqual (_ANZAHL_ABENTEUERERTYPEN_PRO_MENSCH, listeTypen.Count);

		var assassine = listeTypen [0];
		StringAssert.AreEqualIgnoringCase ("assassine", assassine.name);

		var barbarNord = listeTypen [1];
		StringAssert.Contains ("Barbar", barbarNord.name);

		var ordenskrieger = listeTypen [14];
		StringAssert.AreEqualIgnoringCase ("Ordenskrieger", ordenskrieger.name);
	}


	[Test]
	/// <summary>
	/// Rasse Elf, 8 ATypen. Stichprobe auf 3
	/// </summary>
	public void SetSpeciesElfTest ()
	{
		_mCharacter.Spezies = Races.Elf;
		int raceIdElf = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeAbenteuererTypenElf = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceIdElf);
		Assert.AreEqual (_ANZAHL_ABENTEUERERTYPEN_PRO_ELF, listeAbenteuererTypenElf.Count);

		var glücksritter = listeAbenteuererTypenElf [0];
		StringAssert.AreEqualIgnoringCase ("glücksritter", glücksritter.name);

		var krieger = listeAbenteuererTypenElf [1];
		StringAssert.AreEqualIgnoringCase ("krieger", krieger.name);

		var magier = listeAbenteuererTypenElf [7];
		StringAssert.AreEqualIgnoringCase ("magier", magier.name);
	}


	[Test]
	/// <summary>
	/// Rasse Berggnom, 9 ATypen. Stichprobe auf 3
	/// </summary>
	public void SetSpeciesBerggnomTest ()
	{
		_mCharacter.Spezies = Races.Berggnom;
		int raceIdBerggnom = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypenBerggnom = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceIdBerggnom);
		Assert.AreEqual (_ANZAHL_ABENTEUERERTYPEN_PRO_BERGGNOM, listeTypenBerggnom.Count);

		var spitzi = listeTypenBerggnom [2];
		StringAssert.AreEqualIgnoringCase ("spitzbube", spitzi.name);

		var waldi = listeTypenBerggnom [3];
		StringAssert.AreEqualIgnoringCase ("waldläufer", waldi.name);

	}

	[Test]
	/// <summary>
	/// Anzahl Abenteurertypen Elf: 9, Stichprobe 3
	/// </summary>
	public void SetSpeciesWaldgnomTest ()
	{
		const int _NUMBERABENTEURERTYPEN = 9;
		_mCharacter.Spezies = Races.Waldgnom;
		int raceIdWaldgnom = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypenWaldgnom = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceIdWaldgnom);
		Assert.AreEqual (_NUMBERABENTEURERTYPEN, listeTypenWaldgnom.Count);

		var spitzi = listeTypenWaldgnom [2];
		StringAssert.AreEqualIgnoringCase ("spitzbube", spitzi.name);

		var waldi = listeTypenWaldgnom [3];
		StringAssert.AreEqualIgnoringCase ("waldläufer", waldi.name);

	}

	[Test]
	/// <summary>
	/// Anzahl Abenteurertypen Halbling:7, Stichprobe 1
	/// </summary>
	public void SetSpeciesHalblingTest ()
	{
		_mCharacter.Spezies = Races.Halbling;
		int raceIdHalbling = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypenHalblinge = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceIdHalbling);
		Assert.AreEqual (_ANZAHL_ABENTEUERERTYPEN_PRO_HALBLING, listeTypenHalblinge.Count);

		var waldi = listeTypenHalblinge [2];
		StringAssert.AreEqualIgnoringCase ("waldläufer", waldi.name);

	}

	[Test]
	public void SetSpeciesZwergTest ()
	{
		_mCharacter.Spezies = Races.Zwerg;
		int raceIdZwerg = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypenZwerg = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceIdZwerg);
		Assert.AreEqual (_ANZAHL_ABENTEUERERTYPEN_PRO_ZWERG, listeTypenZwerg.Count);

		var beschwoerer = listeTypenZwerg [3];
		StringAssert.AreEqualIgnoringCase ("beschwörer", beschwoerer.name);
	}

}

