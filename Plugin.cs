using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using PlayFab.ClientModels;
using GorillaCookieClicker.Shop;
using System.Net;
using WebSocketSharp.Net;
using Photon.Pun;
using GorillaCookieClicker.Buttons;

namespace GorillaCookieClicker
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

        public static Plugin instance;
        public static AssetBundle bundle;
        public static GameObject GorillaCookieClicker;
        public static GameObject Cookie;
        public static GameObject NextPage1;
        public static GameObject BackPage1;
        public static GameObject SetActiveButton;
        public static GameObject HoverZone;
        public static TextMeshPro PlayerText;
        public string PlayerName;
        public static string assetBundleName = "cookieclicker";
        public static string parentName = "GorillaCookieClicker";

        public static GameObject Buy1;
        public static GameObject Buy2;
        public static GameObject Buy3;
        public static GameObject Buy4;
        public static GameObject Buy5;
        public static GameObject Buy6;
        public static GameObject Buy7;
        public static GameObject Buy8;


        void Start()
		{
			instance = this;
            bundle = LoadAssetBundle("GorillaCookieClicker.AssetBundles." + assetBundleName);
            GorillaCookieClicker = Instantiate(bundle.LoadAsset<GameObject>(parentName));
            GorillaCookieClicker.transform.position = new Vector3(-67.2225f, 11.57f, -82.611f);
            PlayerText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page0/Backround2/PlayersName").GetComponent<TextMeshPro>();
            PlayerName = PhotonNetwork.LocalPlayer.NickName;
            PlayerText.text = PlayerName + "'s Bakery";

            Buy1 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Buttons/Button");
            Buy2 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Buttons/Button2");
            Buy3 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Buttons/Button3");

            Buy4 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Buttons/Button");
            Buy5 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Buttons/Button4");
            Buy6 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Buttons/Button (2)");
            Buy7 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Buttons/Button (3)");
            Buy8 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Buttons/Button (1)");

            SetActiveButton = GameObject.Find("GorillaCookieClicker(Clone)/ToggleActive");
            SetActiveButton.AddComponent<SetActive>();
            SetActiveButton.GetComponent<SetActive>().Object = GameObject.Find("GorillaCookieClicker(Clone)/parent");
            SetActiveButton.GetComponent<SetActive>().setactivetext = GameObject.Find("GorillaCookieClicker(Clone)/ToggleActive/text").GetComponent<TextMeshPro>();
            SetActiveButton.layer = 18;

            Cookie = GameObject.Find("GorillaCookieClicker(Clone)/parent/cookieclicker");
            Cookie.layer = 18;
            Cookie.AddComponent<Cookie>();

            Buy1.AddComponent<BuyMultiplier>();
            Buy1.GetComponent<BuyMultiplier>().Cost = 25;
            Buy1.GetComponent<BuyMultiplier>().Award = 1;
            Buy1.GetComponent<BuyMultiplier>().CostText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Backrounds/Backround6/PlayersName").GetComponent<TextMeshPro>();
            Buy1.layer = 18;

            Buy2.AddComponent<BuyMultiplier>();
            Buy2.GetComponent<BuyMultiplier>().Cost = 100;
            Buy2.GetComponent<BuyMultiplier>().Award = 5;
            Buy2.GetComponent<BuyMultiplier>().CostText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Backrounds/Backround8/PlayersName").GetComponent<TextMeshPro>();
            Buy2.layer = 18;

            Buy3.AddComponent<BuyMultiplier>();
            Buy3.GetComponent<BuyMultiplier>().Cost = 500;
            Buy3.GetComponent<BuyMultiplier>().Award = 25;
            Buy3.GetComponent<BuyMultiplier>().CostText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Backrounds/Backround9/PlayersName").GetComponent<TextMeshPro>();
            Buy3.layer = 18;

            Buy4.AddComponent<BuyPrestige>();
            Buy4.GetComponent<BuyPrestige>().Cost = 1000;
            Buy4.GetComponent<BuyPrestige>().Award = 1;
            Buy4.GetComponent<BuyPrestige>().CostText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Backrounds/Backround6/PlayersName").GetComponent<TextMeshPro>();
            Buy4.layer = 18;

            Buy5.AddComponent<BuyMultiplier>();
            Buy5.GetComponent<BuyMultiplier>().Cost = 1500;
            Buy5.GetComponent<BuyMultiplier>().Award = 100;
            Buy5.GetComponent<BuyMultiplier>().CostText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Backrounds/Backround11/PlayersName").GetComponent<TextMeshPro>();
            Buy5.layer = 18;

            Buy6.AddComponent<BuyPrestige>();
            Buy6.GetComponent<BuyPrestige>().Cost = 4000;
            Buy6.GetComponent<BuyPrestige>().Award = 5;
            Buy6.GetComponent<BuyPrestige>().CostText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Backrounds/Backround6 (2)/PlayersName").GetComponent<TextMeshPro>();
            Buy6.layer = 18;

            Buy7.AddComponent<BuyPrestige>();
            Buy7.GetComponent<BuyPrestige>().Cost = 20000;
            Buy7.GetComponent<BuyPrestige>().Award = 25;
            Buy7.GetComponent<BuyPrestige>().CostText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Backrounds/Backround6 (3)/PlayersName").GetComponent<TextMeshPro>();
            Buy7.layer = 18;

            Buy8.AddComponent<BuyPrestige>();
            Buy8.GetComponent<BuyPrestige>().Cost = 90000;
            Buy8.GetComponent<BuyPrestige>().Award = 100;
            Buy8.GetComponent<BuyPrestige>().CostText = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Backrounds/Backround6 (1)/PlayersName").GetComponent<TextMeshPro>();
            Buy8.layer = 18;

            HoverZone = GameObject.Find("GorillaCookieClicker(Clone)/parent/HoverZone");
            HoverZone.AddComponent<Hover>();
            HoverZone.layer = 18;
            Hover.HoverObject = Cookie;

            NextPage1 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1/Buttons/NextPage");
            NextPage1.layer = 18;
            NextPage1.AddComponent<PageButton>();
            NextPage1.GetComponent<PageButton>().PageToGo = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2");
            NextPage1.GetComponent<PageButton>().PageToLeave = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1");

            BackPage1 = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2/Buttons/NextPage");
            BackPage1.layer = 18;
            BackPage1.AddComponent<PageButton>();
            BackPage1.GetComponent<PageButton>().PageToGo = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page1");
            BackPage1.GetComponent<PageButton>().PageToLeave = GameObject.Find("GorillaCookieClicker(Clone)/parent/Page2");
		}


        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
