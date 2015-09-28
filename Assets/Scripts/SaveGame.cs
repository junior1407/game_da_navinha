using UnityEngine;
using System.Collections;

public class SaveGame

{
	public int gold;
	public int BalasMais;
	public int DanoMais;
	public int SpeedMais;
	public int LifeMais;
	public SaveGame (int balasMais, int danoMais, int speedMais, int lifeMais,int gold)
	{
		this.BalasMais = balasMais;
		this.DanoMais = danoMais;
		this.SpeedMais = speedMais;
		this.LifeMais = lifeMais;
		this.gold = gold;
	}
	public SaveGame ()
	{
		this.BalasMais = 0;
		this.DanoMais = 0;
		this.SpeedMais = 0;
		this.LifeMais = 0;
		this.gold = 100;
	}

	

}


