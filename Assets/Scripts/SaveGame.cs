using UnityEngine;
using System.Collections;

public class SaveGame

{
	public int BalasMais;
	public int DanoMais;
	public int SpeedMais;
	public int LifeMais;
	public SaveGame (int balasMais, int danoMais, int speedMais, int lifeMais)
	{
		this.BalasMais = balasMais;
		this.DanoMais = danoMais;
		this.SpeedMais = speedMais;
		this.LifeMais = lifeMais;
	}
	public SaveGame ()
	{
		this.BalasMais = 0;
		this.DanoMais = 0;
		this.SpeedMais = 0;
		this.LifeMais = 0;
	}

	

}


