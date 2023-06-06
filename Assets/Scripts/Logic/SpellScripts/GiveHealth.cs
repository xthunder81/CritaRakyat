using UnityEngine;
using System.Collections;

public class GiveHealth: SpellEffect 
{
    public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
        new DealDamageCommand(TurnManager.Instance.whoseTurn.PlayerID, specialAmount, TurnManager.Instance.whoseTurn.Health + specialAmount).AddToQueue();
        TurnManager.Instance.whoseTurn.Health += specialAmount;
    }
}
