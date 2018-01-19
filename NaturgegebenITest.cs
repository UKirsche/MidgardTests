using UnityEngine;
using UnityEditor;
using NUnit.Framework;

/// <summary>
/// Naturgegeben I test. Testet: AnB, Abwehr, AbB, Zauber, ZauB
/// </summary>
public class NaturgegebenITest {

	private readonly int _MAX_ANB=2;
	private readonly int _MIN_ANB=-2;

	private readonly int _MIN_ABW = 9;
	private readonly int _MAX_ABW = 13;

	private readonly int _ZAUB_KÄMPFER = 2;
	private readonly int _MIN_ZAUB =7;
	private readonly int _MAX_ZAUB =14;


	private MidgardCharakter mCharacter;

	/// <summary>
	/// Initializes a new instance of the <see cref="NaturgegebenITest"/> class.
	/// </summary>
	public NaturgegebenITest(){
		this.mCharacter = new MidgardCharakter ();
	}

	/// <summary>
	/// Angriffsbonus abängig von Gs (Geschicklichkeit)
	/// </summary>
	[Test]
	public void TestAngriffBonus()
	{
		this.mCharacter.Spezies = Races.Elf;
		mCharacter.Gs = UnityEngine.Random.Range (1, 101); //Zufallswert
		CharacterEngine.ComputeNaturGegebenI(this.mCharacter);

		Assert.LessOrEqual(mCharacter.AnB, _MAX_ANB);
		Assert.GreaterOrEqual(mCharacter.AnB, _MIN_ANB);
	}

	/// <summary>
	/// Raufen errechnet sich aus:  (St + Gw)/20 + AnB. 
	/// Zwergen bekommen einen Zuschlag von +1
	/// </summary>
	[Test]
	public void TestRaufen()
	{
		this.mCharacter.Spezies = Races.Mensch;
		MidgardCharakter zwergChar = new MidgardCharakter ();
		zwergChar.Spezies = Races.Zwerg;
		int Gs = UnityEngine.Random.Range (1, 101); 
		int St = UnityEngine.Random.Range (61, 101); //Min-Wert für Zwerg
		int Gw = UnityEngine.Random.Range (1, 81); //Max-Wert für Zwerg

		//Gleich initialisieren
		mCharacter.Gs = Gs;
		mCharacter.St = St;
		mCharacter.Gw = Gw;
		zwergChar.Gs = Gs;
		zwergChar.St = St;
		zwergChar.Gw = Gw;

		CharacterEngine.ComputeNaturGegebenI(this.mCharacter);
		CharacterEngine.ComputeNaturGegebenI(zwergChar);

		Assert.AreEqual(mCharacter.Raufen+1, zwergChar.Raufen);
	}

	/// <summary>
	/// Der Abwehr-Wert errechnet sich aus Gewandtheit (DFR, S. 36). 
	/// Der Abwehr-Wert schwankt zwischen 9-13.
	/// </summary>
	[Test]
	public void TestAbwehr()
	{
		this.mCharacter.Spezies = Races.Mensch; //Rasse gleichgültig

		for (int i = 0; i < 10; i++) {
			CharacterEngine.ComputeBasisGw (this.mCharacter);
			CharacterEngine.ComputeNaturGegebenI(this.mCharacter);
			Assert.LessOrEqual (this.mCharacter.Abwehr, _MAX_ABW);
			Assert.GreaterOrEqual (this.mCharacter.Abwehr, _MIN_ABW);
		}

	}


	/// <summary>
	/// Der Zauber-Wert errechnet sich aus dem Zaubertalent (DFR, S. 37). 
	/// Der Zauber-Wert schwankt zwischen 7-14 für Zauberer, Nicht-Zauberer haben einen Wert von 2
	/// </summary>
	[Test]
	public void TestZaubern()
	{
		this.mCharacter.Spezies = Races.Mensch; //Rasse gleichgültig
		this.mCharacter.Archetyp = AbenteuerTyp.As;

		for (int i = 0; i < 10; i++) {
			CharacterEngine.ComputeBasisZt (this.mCharacter);
			CharacterEngine.ComputeNaturGegebenI(this.mCharacter);
			Assert.AreEqual (_ZAUB_KÄMPFER, this.mCharacter.Zaubern);
		}


	}
}
