using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
/// Händigkeit:
/// 1-15: rechts
/// 16-19: links
/// 20: beidhändig
/// 
/// Ausnahme Gnome: Immer beidhändig
/// 
/// </summary>
public class HändigkeitTest {

	private MidgardCharakter mCharacter;

	/// <summary>
	/// Initializes a new instance of the <see cref="HändigkeitTest"/> class.
	/// </summary>
	public HändigkeitTest(){
		this.mCharacter = new MidgardCharakter ();
	}

	/// <summary>
	/// Händigkeit für alle Rassen gleich gewürfelt - außer Gnome
	/// </summary>
	[Test]
	public void TestHandAll()
	{
		mCharacter.Spezies = Races.Mensch;
		int w20 = CharacterEngine.ComputeHandWurf (this.mCharacter);
		Hand resultHand = CharacterEngine.GetHandfromWurf(w20);
		var hands = Enum.GetValues (typeof(Hand));
		Assert.Contains (resultHand, hands);

	}

	/// <summary>
	/// Immer beidhändig
	/// </summary>
	[Test]
	public void TestHandGnom()
	{
		int zuFall= UnityEngine.Random.Range (1, 3);
		if (zuFall == 1) {
			mCharacter.Spezies = Races.Waldgnom;
		} else {
			mCharacter.Spezies = Races.Berggnom;
		}

		int w20 = CharacterEngine.ComputeHandWurf (this.mCharacter);
		Hand resultHand = CharacterEngine.GetHandfromWurf(w20);

		Assert.AreEqual (resultHand, Hand.beide);

	}
}
