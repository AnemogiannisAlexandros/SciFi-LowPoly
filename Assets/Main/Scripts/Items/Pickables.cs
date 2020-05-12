using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main
{
    public class Pickables : Item
    {
        public override void CancelInteraction()
        {
            base.CancelInteraction();
            PlayerManager.Instance.GetInventory().AddItem(this);
        }
    }
}
