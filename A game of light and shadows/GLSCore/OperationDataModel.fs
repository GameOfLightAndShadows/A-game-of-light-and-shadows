﻿module GLSCore.OperationDataModel

open GLSCore.CharacterInformation
open GLSCore.GameElement
open GLSCore.GameItemsModel

type StoreOperation = 
    | Purchase
    | Sell

type TransactionOperation = 
    | RemovingFromBill
    | AddingToBill

type StoreTransaction = {
    StoreStock : ItemStack array 
    Bill       : int<usd>
}
with 
    static member Empty = { StoreStock = [| |]; Bill = 0<usd> }

type TeamInformation = {
    Inventory : Inventory 
    Members  : HumanCharacter list
}
with 
    static member Initial = { Inventory = Inventory.InitialInventory; Members = [] }

type BattleChoice = 
    | MeleeAttack 
    | ClassAttack 
    | Defense 
    | SelectItem 

type BattleSequencePhase = 
    | InitializingLevel
    | Move 
    | ``Attack or Defend`` of BattleChoice
    | Rotate 
    | EndTurn

type MatchState = 
    | InProcess 
    | BrainWon 
    | PlayerWon
with 
    static member Initial = InProcess

type BattlePhaseState = {
    NumberOfTurns : int 
    Current : BattleSequencePhase
}
with    
    static member Initial = { NumberOfTurns = 0 ; Current = InitializingLevel }
