using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class NPCLoaderTest 
{

	private NPCS midgardNPCS;


	public NPCLoaderTest(){
		midgardNPCS = SceneResourceReader.GetMidgardResource<NPCS> (SceneResourceReader.MidgardNPCTest);
	}

	[Test]
	public void GetNPCS(){
		List<NPC> npcs = midgardNPCS.npcListe;
		Assert.AreEqual (1, npcs.Count);
	}

	[Test]
	public void GetRootPakete(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Infopaket> infoPakete = npc1.infopakete;
		Assert.AreEqual (1, infoPakete.Count);
	}


	[Test]
	public void GetRootPaket1PaketInfos(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Infopaket> infoPakete = npc1.infopakete;
		Infopaket infoPaket = infoPakete [0];

		Assert.AreEqual (1, infoPaket.infos.Count);
	}

	[Test]
	public void GetMission1Paket1Optionen(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Option> optionen = npc1.missionen[0].infopakete[0].optionspaket.optionen;
		Assert.AreEqual (2, optionen.Count);
	}

	[Test]
	public void GetMission1Paket1Option1Paket1(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Infopaket> infopakete1 = npc1.missionen[0].infopakete[0].optionspaket.optionen[0].infopakete;

		Assert.AreEqual (1, infopakete1.Count);
	}

	[Test]
	public void GetMission1Paket1Option1Paket1Infos(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Infopaket> infopakete1 = npc1.missionen[0].infopakete[0].optionspaket.optionen[0].infopakete;
		List<Info> infopak1infos = infopakete1 [0].infos;
		Assert.AreEqual (3, infopak1infos.Count);
	}

	[Test]
	public void GetMission1Paket1Option1Paket1Option1Beschreibung(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Infopaket> infopakete1 = npc1.missionen[0].infopakete[0].optionspaket.optionen[0].infopakete;
		List<Option> optionen = infopakete1 [0].optionspaket.optionen;
		Option option = optionen [0];
		string beschreibunggeschachtelt = option.Beschreibung;
		Assert.AreEqual ("Wähle geschachtelt 1", beschreibunggeschachtelt);
	}

	[Test]
	public void GetMission1Paket1Option1Paket1Option1Paket1Option1Beschreibung(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Infopaket> infopakete1 = npc1.missionen[0].infopakete[0].optionspaket.optionen[0].infopakete[0].optionspaket.optionen[0].infopakete;
		List<Option> optionen = infopakete1 [0].optionspaket.optionen;
		Option option = optionen [0];
		string beschreibunggeschachtelt = option.Beschreibung;
		Assert.AreEqual ("Wähle geschachtelt 2", beschreibunggeschachtelt);
	}

	[Test]
	public void GetMission1Paket1Option1Beschreibung(){
		NPC npc1 = midgardNPCS.npcListe[0];
		List<Mission> missionen = npc1.missionen;
		List<Option> optionen = missionen[0].infopakete[0].optionspaket.optionen;
		string beschreibung = optionen [0].Beschreibung;
		Assert.AreEqual ("Wähle Option1", beschreibung);
	}




}

