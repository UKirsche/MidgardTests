using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using NUnit.Framework;

public class PsychischeEigenschaftenTest {


	private readonly int  _MIN_D100= 1;
	private readonly int  _MAX_D100= 100;


	private MidgardCharakter mCharacter;

	/// <summary>
	/// Initializes a new instance of the <see cref="PsychischeEigenschaftenTest"/> class.
	/// </summary>
	public PsychischeEigenschaftenTest(){
		this.mCharacter = new MidgardCharakter ();
	}

	/// <summary>
	/// pA wird schon für Menschen bei den möglichen Abenteurertypen getestet. 
	/// Deswegen erfolgt hier nur der Standardtest
	/// </summary>
	[Test]
	public void TestPersönlicheAusstrahlung()
	{
		mCharacter.Spezies = Races.Mensch;
		mCharacter.Archetyp = AbenteuerTyp.BN; //egal
		CharacterEngine.ComputeBasisIn (this.mCharacter);
		CharacterEngine.ComputeErscheinung (this.mCharacter);
		CharacterEngine.ComputePsychisch (this.mCharacter);

		Assert.GreaterOrEqual (mCharacter.pA, _MIN_D100);
		Assert.LessOrEqual (mCharacter.pA, _MAX_D100);

	}

	/// <summary>
	/// ACHTUNG: Im Detail fällt Sb für einige ATypen anders raus, was aber nichts
	/// an den Max-Werten, Min-Werten ändert. Der Code hierfür wurde überprüft.
	/// </summary>
	[Test]
	public void TestWkSb()
	{
		mCharacter.Spezies = Races.Mensch;
		mCharacter.Archetyp = AbenteuerTyp.Gl; //egal

		CharacterEngine.ComputeBasisIn (this.mCharacter);
		CharacterEngine.ComputeBasisKo (this.mCharacter);
		CharacterEngine.ComputePsychisch (this.mCharacter);
		
		CharacterEngine.ComputePsychisch (this.mCharacter);

		Assert.GreaterOrEqual (mCharacter.Wk, _MIN_D100);
		Assert.LessOrEqual (mCharacter.Wk, _MAX_D100);

		Assert.GreaterOrEqual (mCharacter.Sb, _MIN_D100);
		Assert.LessOrEqual (mCharacter.Sb, _MAX_D100);

		Debug.Log (mCharacter.Sb);

	}
}
