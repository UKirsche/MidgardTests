using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class DialogParserTest 
{

	private NPCS midgardNPCS;
	private NPCS midgardNPCS2;


	public DialogParserTest(){

		midgardNPCS = SceneResourceReader.GetMidgardResource<NPCS> (SceneResourceReader.MidgardNPCTest);
		midgardNPCS2 = SceneResourceReader.GetMidgardResource<NPCS> (SceneResourceReader.MidgardNPCTest2);
	}


	/// <summary>
	/// Erster mit Nonsense-XML. Teste Verschachtelung. Code hier eingerückt, muss aber nicht
	/// </summary>
	[Test]
	public void DialgParserTestXML1() {
		DialogParser dialogParser = new DialogParser ();
		List<NPC> npcs = midgardNPCS.npcListe;
		Mission mission = npcs[0].missionen[0];
		dialogParser.StartNode = new DialogNode<object> ();
		dialogParser.StartNode.nodeElement = mission;
		dialogParser.StartNode.typeNodeElement = typeof(Mission);
		dialogParser.StartNode.typeParentNodeElement = null;
		dialogParser.StartNode.parentNode = null;

		//Hier sind im Paket zwei Infos und ein Optionspaket
		List<Info> infos = dialogParser.GetInfos ();
		Assert.AreEqual (2, infos.Count);
		Assert.AreEqual ("Mission 1.", infos [0].content);

		//Optionspaket abholen
		infos = dialogParser.GetInfos();
		Assert.IsNull (infos);

		//Level1
		if (dialogParser.IsOption == true) {
			//Wähle Option 0 (geht normal über UI
			dialogParser.StartNode = dialogParser.optionalStartNodes[0];
			infos = dialogParser.GetInfos();
			Assert.AreEqual (3, infos.Count);
			Assert.AreEqual ("Tja, gut gewählt 1", infos [0].content);
			infos =dialogParser.GetInfos();
			Assert.IsNull (infos);
			//Level 2
			if (dialogParser.IsOption == true) {
				dialogParser.StartNode = dialogParser.optionalStartNodes[0];
				Option optChosen = dialogParser.StartNode.nodeElement as Option;
				Assert.AreEqual("Wähle geschachtelt 1", optChosen.Beschreibung);
				infos = dialogParser.GetInfos();
				Assert.AreEqual (1, infos.Count);
				Assert.AreEqual ("Das wars innerhalb", infos [0].content);
				infos = dialogParser.GetInfos ();
				Assert.IsNull (infos);
				if (dialogParser.IsOption == true) {
					dialogParser.StartNode = dialogParser.optionalStartNodes[0];
				 	optChosen = dialogParser.StartNode.nodeElement as Option;
					Assert.AreEqual("Wähle geschachtelt geschachtelt 1", optChosen.Beschreibung);
					infos = dialogParser.GetInfos();
					Assert.AreEqual (1, infos.Count);
					Assert.AreEqual ("Das wars innerhalinnerhalb", infos [0].content);

					//Springe hoch zum nächsten Infopaket (MoveUpward)
					infos = dialogParser.GetInfos ();
					Assert.AreEqual (1, infos.Count);
					Assert.AreEqual ("Dialog 1", infos [0].content);
				}
			}
		}

	}

	/// <summary>
	/// Testet den normalen Ablauf als kleine Story mit Überprüfung auf vorhandene Optionen. Infos und Optionen werden nacheinander abgefragt
	/// </summary>
	[Test]
	public void DialgParserTestXML2() {
		DialogParser dialogParser = new DialogParser ();
		Option optChosen = null;
		List<NPC> npcs = midgardNPCS2.npcListe;
		Mission mission = npcs[0].missionen[0];
		dialogParser.StartNode = new DialogNode<object> ();
		dialogParser.StartNode.nodeElement = mission;
		dialogParser.StartNode.typeNodeElement = typeof(Mission);
		dialogParser.StartNode.typeParentNodeElement = null;
		dialogParser.StartNode.parentNode = null;

		//Hier sind im Paket zwei Infos und ein Optionspaket
		List<Info> infos = dialogParser.GetInfos ();
		Assert.AreEqual (3, infos.Count);
		Assert.AreEqual ("Mission 1: Du sollst den geflohenen Esel fangen.", infos [0].content);

		infos = dialogParser.GetInfos ();
		if (infos == null) {
			if (dialogParser.IsOption) {
				dialogParser.StartNode = dialogParser.optionalStartNodes[0];
				optChosen = dialogParser.StartNode.nodeElement as Option;
				infos = dialogParser.GetInfos ();
				Assert.AreEqual (2, infos.Count);
			}
		}
		infos = dialogParser.GetInfos ();
		if (dialogParser.IsOption) {
			dialogParser.StartNode = dialogParser.optionalStartNodes[0];
			optChosen = dialogParser.StartNode.nodeElement as Option;
			infos = dialogParser.GetInfos ();
			Assert.AreEqual (1, infos.Count);
		}
		infos = dialogParser.GetInfos ();
		if (dialogParser.IsOption) {
			dialogParser.StartNode = dialogParser.optionalStartNodes[1];
			optChosen = dialogParser.StartNode.nodeElement as Option;
			Assert.AreEqual ("Ich lasse den Eimer stehen.", optChosen.Beschreibung);
			infos = dialogParser.GetInfos ();
			Assert.AreEqual (1, infos.Count);
		}
		infos = dialogParser.GetInfos ();
		if (dialogParser.IsOption) {
			dialogParser.StartNode = dialogParser.optionalStartNodes[0];
			optChosen = dialogParser.StartNode.nodeElement as Option;
			Assert.AreEqual ("Es nervt mich furchtbar... Ich pfeffere das Ding in den Brunnen.", optChosen.Beschreibung);
			infos = dialogParser.GetInfos ();
			Assert.AreEqual (1, infos.Count);
			Assert.AreEqual ("Der Eimer verschwindet mit einem hohlen Gebrüll im Brunnen.", infos [0].content);
		}
		infos = dialogParser.GetInfos ();
		Assert.AreEqual ("Grausig. Vielleicht sollte ich den Eimer doch an mich nehmen?", infos [0].content);
		infos = dialogParser.GetInfos ();
		Assert.AreEqual ("Du bist jetzt recht außer Atem nach dem Szenario mit dem Eimer", infos [0].content);
		infos = dialogParser.GetInfos ();
		Assert.AreEqual ("Da an der Ecke steht endlich der Esel!", infos [0].content);

	}



}
