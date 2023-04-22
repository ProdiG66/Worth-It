using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemListControl : MonoBehaviour {
	[SerializeField]
	private GameObject itemPrefab;


	public int itemIndex { get; set; } = 3;

	public Item[] items {
		get => _items;
		set => _items = value;
	}

	private Item[] _items;

	private void Awake() {
		itemIndex = 3;
		if (transform.childCount < 3)
			return;
		for (int i = 2; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);
	}

	public void AddItem() {
		GameObject item = Instantiate(itemPrefab, transform);
		TextMeshProUGUI itemText = item.GetComponent<TextMeshProUGUI>();
		itemText.text = "Item " + itemIndex;
		itemIndex++;
		UpdateItems();
	}

	public void RemoveItem() {
		if (itemIndex <= 3)
			return;
		Destroy(transform.GetChild(transform.childCount - 1).gameObject);
		itemIndex--;
		UpdateItems();
	}

	public void UpdateAllNames() {
		for (int i = 0; i < transform.childCount; i++) {
			Item item = transform.GetChild(i).GetComponent<Item>();
			item.UpdateName();
		}
	}

	public void UpdateItems() {
		items = GetComponentsInChildren<Item>();
	}
}