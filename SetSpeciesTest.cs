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
/// Zauberkundige Kämpfer
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

	private MidgardCharakter _mCharacter;

	public SetSpeciesTest(){

		_mCharacter = new MidgardCharakter ();
	}

	/// <summary>
	/// Gets the number rassen test. 
	/// </summary>
	[Test]
	public void GetNumberRassenTest(){
		const int _NUMBERRASSEN = 6;
		Rassen midgardRassen = MidgardResourceReader.GetMidgardResource<Rassen> (MidgardResourceReader.MidgardRassen);
		Assert.AreEqual (_NUMBERRASSEN, midgardRassen.rassenListe.Count);
	}


	[Test]
	/// <summary>
	/// Test Rasse Mensch. Ermöglicht 30 Abenteurertypen. Test auf  enthaltenen Assassinen, Barbar und Ordenskrieger
	/// </summary>
	public void SetSpeciesMenschTest ()
	{
		const int _NUMBERABENTEURERTYPEN = 30;
		_mCharacter.Spezies = Races.Mensch;
		int raceId = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypen = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceId);
		Assert.AreEqual (_NUMBERABENTEURERTYPEN, listeTypen.Count);

		var assassine = listeTypen [0];
		StringAssert.AreEqualIgnoringCase ("assassine", assassine.name);

		var barbarNord = listeTypen [1];
		StringAssert.Contains ("Barbar", barbarNord.name);

		var ordenskrieger = listeTypen [14];
		StringAssert.AreEqualIgnoringCase ("Ordenskrieger", ordenskrieger.name);
	}


	[Test]
	public void SetSpeciesElfTest ()
	{
		const int _NUMBERABENTEURERTYPEN = 8;
		_mCharacter.Spezies = Races.Elf;
		int raceId = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypen = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceId);
		Assert.AreEqual (_NUMBERABENTEURERTYPEN, listeTypen.Count);

		var glücksritter = listeTypen [0];
		StringAssert.AreEqualIgnoringCase ("glücksritter", glücksritter.name);

		var krieger = listeTypen [1];
		StringAssert.AreEqualIgnoringCase ("krieger", krieger.name);

		var magier = listeTypen [7];
		StringAssert.AreEqualIgnoringCase ("magier", magier.name);
	}


	[Test]
	public void SetSpeciesBerggnomTest ()
	{
		const int _NUMBERABENTEURERTYPEN = 9;
		_mCharacter.Spezies = Races.Berggnom;
		int raceId = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypen = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceId);
		Assert.AreEqual (_NUMBERABENTEURERTYPEN, listeTypen.Count);

		var spitzi = listeTypen [2];
		StringAssert.AreEqualIgnoringCase ("spitzbube", spitzi.name);

		var waldi = listeTypen [3];
		StringAssert.AreEqualIgnoringCase ("waldläufer", waldi.name);

	}

	[Test]
	public void SetSpeciesWaldgnomTest ()
	{
		const int _NUMBERABENTEURERTYPEN = 9;
		_mCharacter.Spezies = Races.Waldgnom;
		int raceId = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypen = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceId);
		Assert.AreEqual (_NUMBERABENTEURERTYPEN, listeTypen.Count);

		var spitzi = listeTypen [2];
		StringAssert.AreEqualIgnoringCase ("spitzbube", spitzi.name);

		var waldi = listeTypen [3];
		StringAssert.AreEqualIgnoringCase ("waldläufer", waldi.name);

	}

	[Test]
	public void SetSpeciesHalblingTest ()
	{
		const int _NUMBERABENTEURERTYPEN = 7;
		_mCharacter.Spezies = Races.Halbling;
		int raceId = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypen = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceId);
		Assert.AreEqual (_NUMBERABENTEURERTYPEN, listeTypen.Count);

		var waldi = listeTypen [2];
		StringAssert.AreEqualIgnoringCase ("waldläufer", waldi.name);

	}

	[Test]
	public void SetSpeciesZwergTest ()
	{
		const int _NUMBERABENTEURERTYPEN = 9;
		_mCharacter.Spezies = Races.Zwerg;
		int raceId = (int) _mCharacter.Spezies + 1;
		List<AbenteurerTyp> listeTypen = ObjectXMLHelper.GetMidgardObjectAByIndexB<AbenteurerTyp, RasseRef>(MidgardResourceReader.GetMidgardResource<AbenteurerTypen> (MidgardResourceReader.MidgardAbenteurerTypen).listAbenteurerTypen, raceId);
		Assert.AreEqual (_NUMBERABENTEURERTYPEN, listeTypen.Count);

		var beschwoerer = listeTypen [3];
		StringAssert.AreEqualIgnoringCase ("beschwörer", beschwoerer.name);
	}

}

