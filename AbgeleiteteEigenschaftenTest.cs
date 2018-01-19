using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class AbgeleiteteEigenschaftenTest {

	private MidgardCharakter mCharacter;

	private readonly int _MAX_SCHB=5; //Maximaler Schadensbonus 
	private readonly int _MAX_AUSB = 8; //Maximaler Ausdaurbonus

	/// <summary>
	/// Initializes a new instance of the <see cref="AbgeleiteteEigenschaftenTest"/> class.
	/// </summary>
	public	AbgeleiteteEigenschaftenTest(){
		this.mCharacter = new MidgardCharakter();
	}

	/// <summary>
	/// Tests the SchadensBonus. 
	/// Achtung: Die Rasse spielt keine Rolle, negative Werte sind möglich
	/// </summary>
	[Test]
	public void TestSchadensBonus()
	{
		mCharacter.Spezies = Races.Mensch;
		CharacterEngine.ComputeBasisSt (this.mCharacter); //Stärke	
		CharacterEngine.ComputeBasisGs(this.mCharacter); //Gs
		CharacterEngine.ComputeAbgeleiteteEigenschaften (this.mCharacter);

		int SchB = this.mCharacter.SchB;
		Assert.LessOrEqual (SchB, _MAX_SCHB);
	}

	/// <summary>
	/// Tests the AusdauerBonus. 
	/// Achtung: Die Rasse spielt keine Rolle, negative Werte sind möglich
	/// </summary>
	[Test]
	public void TestAusdauerBonus()
	{
		mCharacter.Spezies = Races.Mensch;
		CharacterEngine.ComputeBasisKo (this.mCharacter); //Stärke	
		CharacterEngine.ComputeBasisGs(this.mCharacter); //Gs
		CharacterEngine.ComputeAbgeleiteteEigenschaften (this.mCharacter);

		int AusB = this.mCharacter.AusB;
		Assert.LessOrEqual (AusB, _MAX_AUSB);
	}
}
