﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this class will take all decisions for AI. 

public class AITurnMaker : TurnMaker
{

    public override void OnTurnStart()
    {
        base.OnTurnStart();
        // dispay a message that it is enemy`s turn
        new ShowMessageCommand("Giliran Lawan", 2.0f).AddToQueue();
        p.DrawACard();
        StartCoroutine(MakeAITurn());
    }

    // THE LOGIC FOR AI
    IEnumerator MakeAITurn()
    {
        bool strategyAttackFirst = false;
        if (Random.Range(0, 2) == 0)
            strategyAttackFirst = true;

        while (MakeOneAIMove(strategyAttackFirst))
        {
            yield return null;
        }

        InsertDelay(1f);

        TurnManager.Instance.EndTurn();
    }

    bool MakeOneAIMove(bool attackFirst)
    {
        if (Command.CardDrawPending())
            return true;
        else if (attackFirst)
            return AttackWithACreature() || PlayACardFromHand(); //|| UseHeroPower();
        else
            return PlayACardFromHand() || AttackWithACreature(); //|| UseHeroPower();
    }

    bool PlayACardFromHand()
    {
        foreach (CardLogic c in p.hand.CardsInHand)
        {
            if (c.CanBePlayed)
            {
                if (c.ca.MaxHealth == 0)
                {
                    // code to play a spell from hand
                    // TODO: depending on the targeting options, select a random target.
                    if (c.ca.Targets == TargetingOptions.NoTarget)
                    {
                        p.PlayASpellFromHand(c, null);
                        InsertDelay(1.5f);
                        //Debug.Log("Card: " + c.ca.name + " can be played");
                        return true;
                    }

                    // this gets all available targets for the targeted spell:
                    var targets = GetTargets(c.ca.Targets);

                    if (targets.Count > 0)
                    {
                        // this plays a spell and selects a random target from the list:
                        p.PlayASpellFromHand(c, targets[Random.Range(0, targets.Count - 1)]);
                        InsertDelay(1.5f);
                        return true;
                    }

                }

                else
                {
                    // it is a creature card
                    p.PlayACreatureFromHand(c, 0);
                    InsertDelay(1.5f);
                    return true;
                }

            }
            //Debug.Log("Card: " + c.ca.name + " can NOT be played");
        }
        return false;
    }


    bool AttackWithACreature()
    {
        foreach (CreatureLogic cl in p.table.CreaturesOnTable)
        {
            if (cl.AttacksLeftThisTurn > 0)
            {
                // attack a random target with a creature
                if (p.otherPlayer.table.CreaturesOnTable.Count > 0)
                {
                    int index = Random.Range(0, p.otherPlayer.table.CreaturesOnTable.Count);
                    CreatureLogic targetCreature = p.otherPlayer.table.CreaturesOnTable[index];
                    cl.AttackCreature(targetCreature);
                }
                else
                    cl.GoFace();

                InsertDelay(1f);
                //Debug.Log("AI attacked with creature");
                return true;
            }
        }
        return false;
    }

    void InsertDelay(float delay)
    {
        new DelayCommand(delay).AddToQueue();
    }

    private List<ICharacter> GetTargets(TargetingOptions targetingOptions)
    {
        var list = new List<ICharacter>();

        switch (targetingOptions)
        {
            case TargetingOptions.AllCreatures:
                list.AddRange(p.table.CreaturesOnTable);
                list.AddRange(p.otherPlayer.table.CreaturesOnTable);
                break;
            case TargetingOptions.EnemyCreatures:
                list.AddRange(p.otherPlayer.table.CreaturesOnTable);
                break;
            case TargetingOptions.YourCreatures:
                list.AddRange(p.table.CreaturesOnTable);
                break;
            case TargetingOptions.AllCharacters:
                list.AddRange(p.table.CreaturesOnTable);
                list.AddRange(p.otherPlayer.table.CreaturesOnTable);
                list.Add(p);
                list.Add(p.otherPlayer);
                break;
            case TargetingOptions.EnemyCharacters:
                list.AddRange(p.otherPlayer.table.CreaturesOnTable);
                list.Add(p.otherPlayer);
                break;
            case TargetingOptions.YourCharacters:
                list.AddRange(p.table.CreaturesOnTable);
                list.Add(p);
                break;
        }

        return list;
    }
    
}
