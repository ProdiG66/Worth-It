using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompareComponent : MonoBehaviour {
	[SerializeField]
	private ItemListControl _itemListControl;

	[SerializeField]
	private TextMeshProUGUI answer;

	private Item _minUnit;
	private Item _maxUnit;

	public Item minUnit {
		get => _minUnit;
		set => _minUnit = value;
	}

	public Item maxUnit {
		get => _maxUnit;
		set => _maxUnit = value;
	}

	public void Compare() {
		_itemListControl.UpdateItems();
		Item[] items = _itemListControl.items;
		if (items.Length <= 1) {
			Debug.Log("Array must contain at least 2 items for comparison.");
			return;
		}

		float minUnitPrice = items[0].unitPrice;
		float maxUnitPrice = items[0].unitPrice;

		for (int i = 1; i < items.Length; i++) {
			float unitPrice = items[i].unitPrice;

			if (unitPrice < minUnitPrice) {
				minUnitPrice = unitPrice;
				minUnit = items[i];
			}

			if (unitPrice > maxUnitPrice) {
				maxUnitPrice = unitPrice;
				maxUnit = items[i];
			}
		}

		Debug.Log("Minimum unit price: " + minUnitPrice);
		Debug.Log("Maximum unit price: " + maxUnitPrice);
		TextMeshProUGUI cheapest = minUnit.GetComponent<TextMeshProUGUI>();
		answer.text = cheapest.text + " is the Cheapest!";
	}
}