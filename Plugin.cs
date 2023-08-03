using System;
using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using Utilla;
using System.Threading.Tasks;
using ConfigMOTD.Scripts;

namespace ConfigMOTD
{
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin("azir.configmotd", "CONFIGMOTD", "1.0.0")]
	public class Plugin : BaseUnityPlugin
	{
		Text MessageOfTheDwayText;

		async void Start()
		{
			Utilla.Events.GameInitialized += OnGameInitialized;

			await Task.Delay(999);

			MessageOfTheDwayText.text = ConfigMOTD.Scripts.Config.TopText.Value;
		}

		void OnEnable()
		{
			MessageOfTheDwayText.text = ConfigMOTD.Scripts.Config.TopText.Value;

			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			MessageOfTheDwayText.text = "MESSAGE OF THE DAY";

			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			MessageOfTheDwayText = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>();
			ConfigMOTD.Scripts.Config.Initalize();
		}
	}
}
