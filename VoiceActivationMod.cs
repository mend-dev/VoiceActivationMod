using MelonLoader;
using BTD_Mod_Helper;
using VoiceActivationMod;
using UnityEngine;
using System;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Simulation.Map.Triggers;
using Il2CppSystem;
using static Il2CppSystem.DateTimeParse;
using static Il2CppSystem.Linq.Expressions.Interpreter.CastInstruction.CastInstructionNoT;
using UnityEngine.Device;
using BTD_Mod_Helper.Extensions;
using Random = System.Random;
using Il2CppSystem.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Il2CppAssets.Scripts.Simulation.Bloons;

[assembly: MelonInfo(typeof(VoiceActivationMod.VoiceActivationMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace VoiceActivationMod;

public class VoiceActivationMod : BloonsTD6Mod {

    bool moneyFrozen = false;
    double moneyFreezed = 0d;

    public override void OnApplicationStart() {
        ModHelper.Msg<VoiceActivationMod>("VoiceActivationMod loaded!");
    }

    public override void OnUpdate() {
        base.OnUpdate();

        if (InGame.instance != null && InGame.instance.bridge != null) {
            InGame instance = InGame.instance;

            if (moneyFrozen && instance.GetCash() > moneyFreezed) {
                instance.SetCash(moneyFreezed);
            } else if (moneyFrozen) {
                moneyFreezed = instance.GetCash();
            }

            int round = instance.bridge.GetCurrentRound();

            if (Input.GetKeyDown(KeyCode.F1)) {
                // Red
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Red, 100, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Red, round) * 100);
            } else if (Input.GetKeyDown(KeyCode.F2)) {
                // Blue
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Blue, 100, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Blue, round) * 100);
            } else if (Input.GetKeyDown(KeyCode.F3)) {
                // Green
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Green, 90, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Green, round) * 90);
            } else if (Input.GetKeyDown(KeyCode.F4)) {
                // Yellow
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Yellow, 80, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Yellow, round) * 80);
            } else if (Input.GetKeyDown(KeyCode.F5)) {
                // Pink
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Pink, 70, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Pink, round) * 70);
            } else if (Input.GetKeyDown(KeyCode.F6)) {
                // Black
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Black, 60, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Black, round) * 60);
            } else if (Input.GetKeyDown(KeyCode.F7)) {
                // White
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.White, 60, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.White, round) * 60);
            } else if (Input.GetKeyDown(KeyCode.F8)) {
                // Zebra
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Zebra, 50, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Zebra, round) * 50);
            } else if (Input.GetKeyDown(KeyCode.F9)) {
                // Lead
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Lead, 50, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Lead, round) * 50);
            } else if (Input.GetKeyDown(KeyCode.F10)) {
                // Purple
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Purple, 50, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Purple, round) * 50);
            } else if (Input.GetKeyDown(KeyCode.F11)) {
                // Rainbow
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Rainbow, 40, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Rainbow, round) * 40);
            } else if (Input.GetKeyDown(KeyCode.F12)) {
                // Ceramic
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Ceramic, 30, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Ceramic, round) * 30);
            } else if (Input.GetKeyDown(KeyCode.F13)) {
                // Moab
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Moab, 8, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Moab, round) * 8);
            } else if (Input.GetKeyDown(KeyCode.F14)) {
                // Bfb
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Bfb, 4, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Bfb, round) * 4);
            } else if (Input.GetKeyDown(KeyCode.F15)) {
                // Zomg
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Zomg, 2, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Zomg, round) * 2);
            } else if (Input.GetKeyDown(KeyCode.Keypad0)) {
                // Ddt
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Ddt, 8, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Ddt, round) * 8);
            } else if (Input.GetKeyDown(KeyCode.Keypad1)) {
                // Bad
                instance.bridge.SpawnBloons(GetBloomEmissionArray(BloonType.Bad, 1, 15), round, 0);
                instance.SetCash(instance.GetCash() - GetBloonValue(BloonType.Bad, round));
            } else if (Input.GetKeyDown(KeyCode.Keypad2)) {
                // Bloonarius
                instance.bridge.SpawnBloons(GetBloomEmissionArray(GetBossType("Bloonarius", round), 1, 15), round, 0);
            } else if (Input.GetKeyDown(KeyCode.Keypad3)) {
                // Dreadbloon
                instance.bridge.SpawnBloons(GetBloomEmissionArray(GetBossType("Dreadbloon", round), 1, 15), round, 0);
            } else if (Input.GetKeyDown(KeyCode.Keypad4)) {
                // Lych
                instance.bridge.SpawnBloons(GetBloomEmissionArray(GetBossType("Lych", round), 1, 15), round, 0);
            } else if (Input.GetKeyDown(KeyCode.Keypad5)) {
                // Vortex
                instance.bridge.SpawnBloons(GetBloomEmissionArray(GetBossType("Vortex", round), 1, 15), round, 0);
            } else if (Input.GetKeyDown(KeyCode.Keypad6)) {
                // Sell random monkey (Monkey)
                Il2CppSystem.Collections.Generic.List<TowerToSimulation> tts = InGame.instance.bridge.GetAllTowers();
                if (tts.Count <= 0) { return; }
                Random rnd = new();
                int tower = rnd.Next(tts.Count);
                float value = tts[tower].sellFor;
                InGame.instance.bridge.SellTower(tts[tower].Id);
                if (!moneyFrozen) {
                    InGame.instance.bridge.SetCash(InGame.instance.bridge.GetCash() - value);
                }
            } else if (Input.GetKeyDown(KeyCode.Keypad7)) {
                // Take away money
                InGame.instance.bridge.SetCash(InGame.instance.bridge.GetCash() - ((InGame.instance.bridge.GetCurrentRound() + 1) * 50));
            } else if (Input.GetKeyDown(KeyCode.Keypad8)) {
                // Sened next few rounds
                InGame.instance.bridge.SendRaceRound();
                InGame.instance.bridge.SendRaceRound();
                InGame.instance.bridge.SendRaceRound();
                InGame.instance.bridge.SendRaceRound();
            } else if (Input.GetKeyDown(KeyCode.Keypad9)) {
                // Disable abilities
                Task task = new(LockAbilitiesCooldown);
                task.Start();
            } else if (Input.GetKeyDown(KeyCode.KeypadDivide)) {
                // Disable purchasing
                Task task = new(LockPurchasingCooldown);
                task.Start();
            } else if (Input.GetKeyDown(KeyCode.KeypadMultiply)) {
                // Disable upgrades
                Task task = new(LockUpgradesCooldown);
                task.Start();
            } else if (Input.GetKeyDown(KeyCode.KeypadMinus)) {
                // Disable money gain
                moneyFreezed = InGame.instance.bridge.GetCash();
                Task task = new(MoneyFreezeCooldown);
                task.Start();
            } else if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
                // Teleport random tower
                Il2CppSystem.Collections.Generic.List<TowerToSimulation> tts = InGame.instance.bridge.GetAllTowers();
                if (tts.Count <= 0) { return; }
                Random rnd = new();
                int tower = rnd.Next(tts.Count);
                float x = ((float)(rnd.NextDouble() - 0.5) * 2) * 147f;
                float y = ((float)(rnd.NextDouble() - 0.5) * 2) * 114f;
                tts[tower].tower.PositionTower(new Il2CppAssets.Scripts.Simulation.SMath.Vector2(x, y));
            } else if (Input.GetKeyDown(KeyCode.KeypadEquals)) {
                // Blind screen
            } else if (Input.GetKeyDown(KeyCode.KeypadPeriod)) {
                // Upgrage all bloons by 1 level
            } else if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
                // Increase all bloon speeds by 2x
            }
        }

        string GetNextBloonType(string bloonId) {
            return bloonId switch {
                "Red" => "Blue",
                "Blue" => "Green",
                "Green" => "Yellow",
                "Yellow" => "Pink",
                "Pink" => "White",
                "Black" => "Zebra",
                "White" => "Zebra",
                "Zebra" => "Rainbow",
                "Lead" => "Rainbow",
                "Purple" => "Rainbow",
                "Rainbow" => "Ceramic",
                "Ceramic" => "Moab",
                "Moab" => "Bfb",
                "Bfb" => "Zomg",
                "Zomg" => "Bad",
                "Ddt" => "Bad",
                "Bad" => "Bad",
                _ => "Red",
            };
        }

        void MoneyFreezeCooldown() {
            MelonLogger.Msg("Freezeing Money");
            moneyFrozen = true;
            Thread.Sleep(30 * 1000);
            MelonLogger.Msg("Unfreezing Money");
            moneyFrozen = false;
        }

        void LockUpgradesCooldown() {
            MelonLogger.Msg("Locking Upgrades");
            InGame.instance.lockTowerUpgrades = true;
            Thread.Sleep(60 * 1000);
            MelonLogger.Msg("Unlocking Upgrades");
            InGame.instance.lockTowerUpgrades = false;
        }

        void LockPurchasingCooldown() {
            MelonLogger.Msg("Locking Purchasing");
            InGame.instance.lockTowerPurchases = true;
            Thread.Sleep(120 * 1000);
            MelonLogger.Msg("Unlocking Purchasing");
            InGame.instance.lockTowerPurchases = false;
        }

        void LockAbilitiesCooldown() {
            MelonLogger.Msg("Locking Abilities");
            InGame.instance.lockAbilities = true;
            Thread.Sleep(60 * 1000);
            MelonLogger.Msg("Unlocking Abilities");
            InGame.instance.lockAbilities = false;
        }

        double GetBloonValue(string bloon, int round) {
            float profitMultipler = GetProfitMultiplier(round);

            return bloon switch {
                "Red" => 1d * profitMultipler,
                "Blue" => 2d * profitMultipler,
                "Green" => 3d * profitMultipler,
                "Yellow" => 4d * profitMultipler,
                "Pink" => 5d * profitMultipler,
                "Black" => 11d * profitMultipler,
                "White" => 11d * profitMultipler,
                "Zebra" => 23d * profitMultipler,
                "Lead" => 23d * profitMultipler,
                "Purple" => 11d * profitMultipler,
                "Rainbow" => 47d * profitMultipler,
                "Ceramic" => 95d * profitMultipler,
                "Moab" => 381d * profitMultipler,
                "Bfb" => 1525d * profitMultipler,
                "Zomg" => 6101d * profitMultipler,
                "Ddt" => 381d * profitMultipler,
                "Bad" => 13346d * profitMultipler,
                _ => 0d,
            };
        }

        float GetProfitMultiplier(int round) {
            if (round >= 0 && round <= 50) {
                return 1f;
            } else if (round >= 51 && round <= 60) {
                return 0.5f;
            } else if (round >= 61 && round <= 85) {
                return 0.2f;
            } else if (round >= 86 && round <= 100) {
                return 0.1f;
            } else if (round >= 101 && round <= 120) {
                return 0.05f;
            } else if (round >= 121) {
                return 0.02f;
            }

            return 1f;
        }
        
        string GetBossType(string boss, int round) {
            int bossLevel = GetBossLevel(round);
            return boss + bossLevel;
        }

        int GetBossLevel(int round) {
            if (round >= 0 && round <= 59) {
                return 1;
            } else if (round >= 60 && round <= 79) {
                return 2;
            } else if (round >= 80 && round <= 99) {
                return 3;
            } else if (round >= 100 && round <= 119) {
                return 4;
            } else if (round >= 120) {
                return 5;
            }

            return 1;
        }

        Il2CppReferenceArray<BloonEmissionModel> GetBloomEmissionArray(string bloon, int amount, int spawnTime) {
            Il2CppReferenceArray<BloonEmissionModel> bme = new(amount);
            for (int i = 0; i < bme.Length; i++) {
                bme[i] = new BloonEmissionModel(bloon, i * spawnTime, bloon);
            }
            return bme;
        }
    }
}