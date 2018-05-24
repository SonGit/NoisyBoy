using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FinalScoreUI : MonoBehaviour {

	void Update ()
	{
		GetComponent<TextMeshProUGUI>().text = "" + DataController.instance.GetHighestPlayerScore ().ToString();
	}

}
