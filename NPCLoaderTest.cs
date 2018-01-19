using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class NPCLoaderTest 
{

	private NPCS midgardNPCS;


	public NPCLoaderTest(){

		midgardNPCS = SceneResourceReader.GetMidgardResource<NPCS> (SceneResourceReader.MidgardNPC);
	}

	[Test]
	public void GetNPCS(){
		List<NPC> npcs = midgardNPCS.npcListe;
		Assert.AreEqual (5, npcs.Count);
	}

	[Test]
	public void GetInfoPaket(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Infopaket> infoPakete = npc1.infopakete;
		Assert.AreEqual (1, infoPakete.Count);
	}

	[Test]
	public void GetInfos(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Infopaket> infoPakete = npc1.infopakete;
		Infopaket infoPaket = infoPakete [0];

		Assert.AreEqual (2, infoPaket.infos.Count);
	}


}

