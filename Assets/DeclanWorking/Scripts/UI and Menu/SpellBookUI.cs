using UnityEngine;
using UnityEngine.UI;

public class SpellBookUI : MonoBehaviour
{
	public PlayerController p1;
	public PlayerController p2;
	public Image[] P1BookInfo;
	public Image[] P2BookInfo;
	public Sprite[] FireIcons;
	public Sprite[] FrostIcons;
	public Sprite[] WindIcons;
	public Sprite[] EarthIcons;
	public Sprite EmptyIcon;

	private GameObject Canv;

	// Token: 0x040033CE RID: 13262
	private Text GMText;

	// Token: 0x040033CF RID: 13263
	private Text KOText;

	// Token: 0x040033D0 RID: 13264
	private GameObject GM;

	// Token: 0x040033D1 RID: 13265
	private GameObject KO;
	
	void Start()
	{

	}

	void Update()
	{
		switch (p1.playerElement)
		{
			case PlayerController.PlayerCurrentElement.Fire:
				SetPlayerUIFire(P1BookInfo);
				break;
			case PlayerController.PlayerCurrentElement.Wind:
				SetPlayerUIWind(P1BookInfo);
				break;
			case PlayerController.PlayerCurrentElement.Frost:
				SetPlayerUIFrost(P1BookInfo);
				break;
			case PlayerController.PlayerCurrentElement.Earth:
				SetPlayerUIEarth(P1BookInfo);
				break;
			default:
				SetPlayerUINone(P1BookInfo);
				break;
		}

		switch (p2.playerElement)
		{
			case PlayerController.PlayerCurrentElement.Fire:
				SetPlayerUIFire(P2BookInfo);
				break;
			case PlayerController.PlayerCurrentElement.Wind:
				SetPlayerUIWind(P2BookInfo);
				break;
			case PlayerController.PlayerCurrentElement.Frost:
				SetPlayerUIFrost(P2BookInfo);
				break;
			case PlayerController.PlayerCurrentElement.Earth:
				SetPlayerUIEarth(P2BookInfo);
				break;
			default:
				SetPlayerUINone(P2BookInfo);
				break;
		}
	}

	void SetPlayerUIFire(Image[] playerUI)
	{
		playerUI[0].sprite = FireIcons[0];
		playerUI[1].sprite = FireIcons[1];
		playerUI[2].sprite = FireIcons[2];
	}

	void SetPlayerUIWind(Image[] playerUI)
	{
		playerUI[0].sprite = WindIcons[0];
		playerUI[1].sprite = WindIcons[1];
		playerUI[2].sprite = WindIcons[2];
	}

	void SetPlayerUIFrost(Image[] playerUI)
	{
		playerUI[0].sprite = FrostIcons[0];
		playerUI[1].sprite = FrostIcons[1];
		playerUI[2].sprite = FrostIcons[2];
	}

	void SetPlayerUIEarth(Image[] playerUI)
	{
		playerUI[0].sprite =  EarthIcons[0];
		playerUI[1].sprite =  EarthIcons[1];
		playerUI[2].sprite =  EarthIcons[2];
	}

	void SetPlayerUINone(Image[] playerUI)
	{
		playerUI[0].sprite = EmptyIcon;
		playerUI[1].sprite = EmptyIcon;
		playerUI[2].sprite = EmptyIcon;
	}
}
