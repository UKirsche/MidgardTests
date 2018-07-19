using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class CharacterSaveTest 
{
	private MidgardCharakter mCharacter;


	public CharacterSaveTest(){

		//Creates empty character
		mCharacter = new MidgardCharakter ();
		FillMidgardCharacterExample ();

	}

	/// <summary>
	/// Rudimentärer Midgard-Character
	/// </summary>
	private void FillMidgardCharacterExample(){
		//1.
		mCharacter.Spezies = Races.Mensch;
		mCharacter.Archetyp = AbenteuerTyp.As;
		mCharacter.Sex = Geschlecht.Frau;

		//2.
		mCharacter.St = 89;
		mCharacter.Gs = 91;
		mCharacter.Ko = 92;
		mCharacter.Gw = 33;
		mCharacter.In = 74;
		mCharacter.Zt = 34;

		//3. 
		mCharacter.B = 24;
		mCharacter.AnB = 1;
		mCharacter.AbB = 1;
		mCharacter.pA = 53;
		mCharacter.Abwehr = 11;

		InventoryItem itemTest = new InventoryItem (12, "Test", "13");
		InventoryItem itemWaffeTest = new InventoryItem (13, "Waffetest", "14");
		InventoryItem itemZauberTest = new InventoryItem (14, "Zaubertest", "15");

		mCharacter.fertigkeiten.Add (itemTest);
		mCharacter.waffenFertigkeiten.Add (itemWaffeTest);
		mCharacter.zauberFormeln.Add (itemZauberTest);

	}

	[Test]
	public void SaveMidgardCharacter(){
		bool retval = MidgardCharacterSaveLoad.Save (mCharacter);
		Assert.IsTrue (retval);
	}

	[Test]
	public void LoadProcessMidgardCharacter(){
		bool retval = MidgardCharacterSaveLoad.Load ();
		Assert.IsTrue (retval);
	}

	[Test]
	public void LoadMidgardCharacter(){
		MidgardCharacterSaveLoad.Load ();
		MidgardCharakter mCharLoaded = MidgardCharacterSaveLoad.savedCharacters [0];

		Assert.AreEqual (mCharacter.St, mCharLoaded.St);
		Assert.AreEqual (mCharacter.fertigkeiten[0].name, mCharLoaded.fertigkeiten[0].name);
		Assert.AreEqual (mCharacter.waffenFertigkeiten[0].name, mCharLoaded.waffenFertigkeiten[0].name);
		Assert.AreEqual (mCharacter.zauberFormeln[0].name, mCharLoaded.zauberFormeln[0].name);
	}



}
