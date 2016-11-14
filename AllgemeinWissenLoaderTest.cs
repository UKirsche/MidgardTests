using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class AllgemeinWissenLoaderTest 
{
	private const int _NUMBERFACHLAND = 34;
	private const int _NUMBERFACHSTADT = 29;
	private const int _NUMBERWAFFENLAND = 2;
	private const int _NUMBERWAFFENSTADT = 2;

	private Allgemeinwissen midgardAllgemeinwissen;


	public AllgemeinWissenLoaderTest(){
		
		midgardAllgemeinwissen = MidgardResourceReader.GetMidgardResourceForTests<Allgemeinwissen> (MidgardResourceReader.MidgardAllgemeinWissen);
	}

	[Test]
	public void GetAllgemeinFachkenntnisse(){
		Assert.AreEqual (0, 0);
	}

	[Test]
	public void GetAllgemeinWissenLandTest(){
		List<FachkenntnisRefAllgemein> fachkenntnisse = midgardAllgemeinwissen.landAllgemeinWissen.fachkenntnisse;
		List<WaffenfertigkeitRef> waffen = midgardAllgemeinwissen.landAllgemeinWissen.waffen;
		int numberFachkenntnisseLand = fachkenntnisse.Count;
		int numberWaffenLand = waffen.Count;
		Assert.AreEqual (_NUMBERFACHLAND, numberFachkenntnisseLand);
		Assert.AreEqual (_NUMBERWAFFENLAND, numberWaffenLand);
	}

	[Test]
	public void GetAllgemeinWissenStadtTest(){
		List<FachkenntnisRefAllgemein> fachkenntnisse = midgardAllgemeinwissen.stadtAllgemeinWissen.fachkenntnisse;
		List<WaffenfertigkeitRef> waffen = midgardAllgemeinwissen.stadtAllgemeinWissen.waffen;
		int numberFachkenntnisseStadt = fachkenntnisse.Count;
		int numberWaffenStadt = waffen.Count;
		Assert.AreEqual (_NUMBERFACHSTADT, numberFachkenntnisseStadt);
		Assert.AreEqual (_NUMBERWAFFENSTADT, numberWaffenStadt);
	}


}

