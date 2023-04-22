using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveItemButton : MonoBehaviour {
	private ItemListControl _itemListControl;
	private Button _button;

	private void Awake() {
		_itemListControl = GetComponentInParent<ItemListControl>();
		_button = GetComponent<Button>();
		_button.onClick.AddListener(RemoveItem);
	}

	public void RemoveItem() {
		if (_itemListControl.itemIndex <= 3)
			return;
		Transform item = transform.parent.parent;
		item.SetParent(null);
		_itemListControl.itemIndex--;
		_itemListControl.UpdateAllNames();
		Destroy(item.gameObject);
		_itemListControl.UpdateItems();
	}
}