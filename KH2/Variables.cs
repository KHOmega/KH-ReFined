/*
==================================================
      KINGDOM HEARTS - RE:FIXED FOR 2 FM!
       COPYRIGHT TOPAZ WHITELOCK - 2022
 LICENSED UNDER DBAD. GIVE CREDIT WHERE IT'S DUE! 
==================================================
*/

using System;
using System.Media;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using DiscordRPC;

namespace ReFixed
{
    public class Variables
    {
        private static Assembly ExeAssembly = Assembly.GetExecutingAssembly();
        private static FileVersionInfo FileInfo = FileVersionInfo.GetVersionInfo(
            ExeAssembly.Location
        );
        private static String FileVersion = FileInfo.FileVersion;

        // Set to true if using Dual Audio
        public const bool DualAudio = true;

        public static bool Initialized = false;

        public static Task DiscordTask;
        public static Task AutoSaveTask;
        public static CancellationToken TaskToken;
        public static CancellationTokenSource CancelSource;

        public static DiscordRpcClient DiscordClient = new DiscordRpcClient("833511404274974740");

        public static SoundPlayer SaveSFX = new SoundPlayer(ExeAssembly.GetManifestResourceStream("sfxSave.wav"));

        public static string[] BattleImages = { "safe", "mob", "boss" };
        public static string[] WorldImages =
        {
            "",
            "",
            "tt",
            "",
            "hb",
            "bb",
            "he",
            "al",
            "mu",
            "po",
            "lk",
            "lm",
            "dc",
            "wi",
            "nm",
            "wm",
            "ca",
            "tr",
            "eh"
        };

        public static string[] FormText =
        {
            "None",
            "Valor",
            "Wisdom",
            "Limit",
            "Master",
            "Final",
            "Anti"
        };
        public static string[] ModeText =
        {
            "Beginner Mode",
            "Standard Mode",
            "Proud Mode",
            "Critical Mode"
        };

        public static string[] FormNames =
        {
            "P_EX100{0}",
            "P_EX100{0}_BTLF",
            "P_EX100{0}_MAGF",
            "P_EX100{0}_TRIF",
            "P_EX100{0}_ULTF",
            "P_EX100{0}_HTLF"
        };

        public static string[] PartyNames = { "P_EX020{0}", "P_EX030{0}" };

        public static ulong[] ObjentryAddresses = { 0x24BFA72, 0x24BFD72, 0x24E7852 };

        public static ulong[] MPSEQDAddresses = { 0x4A03C6, 0x4A0376, 0x4A035A, 0x4A038A };

        public static byte[] MPSEQDValues = { 0x7A, 0x78, 0x18, 0x79 };

        public static ulong MagicLVAddress = 0x4460F6;
        public static ulong MagicLV2Address = 0x446131;

        public static Process GameProcess;
        public static IntPtr GameHandle;

        public static ulong GameAddress;
        public static ulong ExeAddress;

        public static bool SkipRoxas;
        public static byte SkipStage;
        public static bool SkipComplete;

        public static bool Debounce;

        public static ulong BaseAddress =
            !FileVersion.Contains("8") ? (ulong)0x56450E : (ulong)0x56454E;

        public static ulong InputAddress =
            !FileVersion.Contains("8") ? (ulong)0x1ACF7B : (ulong)0x1ACF3B;
        public static ulong ConfigAddress = 0x446D06;

        public static ulong ConfirmAddress =
            !FileVersion.Contains("8") ? (ulong)0x365550 : (ulong)0x365520;
        public static ulong FramerateAddress =
            !FileVersion.Contains("8") ? (ulong)0x36553C : (ulong)0x36550C;

        public static ulong LimiterAddress = 0x553EBA;

        public static ulong PaxFormatterAddress =
            !FileVersion.Contains("8") ? (ulong)0x61FD2 : (ulong)0x61F92;
        public static ulong BattleFormatterAddress =
            !FileVersion.Contains("8") ? (ulong)0x5F87A : (ulong)0x5F83A;
        public static ulong AnbFormatterAddress =
            !FileVersion.Contains("8") ? (ulong)0x52A02 : (ulong)0x529C2;
        public static ulong EventFormatterAddress =
            !FileVersion.Contains("8") ? (ulong)0x52A72 : (ulong)0x52A32;

        public static ulong InstructionAddress =
            !FileVersion.Contains("8") ? (ulong)0x152160 : (ulong)0x152220;

        public static ulong[] ConfigTextAddresses = { 0x2565A59, 0x2565C94 };
        public static ulong[] TitleTextAddresses =
        {
            0x256E10A,
            0x256E125,
            0x256E12C,
            0x256E152,
            0x256E295
        };

        public static ushort[] AudioOffsets = { 0xEB3F, 0xEB47, 0xEB58, 0xEB58 };
        public static ulong[] SaveTextAddresses = { 0x2565A59, 0x2565C9B, 0x2565CC2 };
        public static ulong[] AudioTextAddresses = { 0x2565A59, 0x2565C81, 0x2565C89, 0x2565C9A };
        public static ulong[] AudioOffsetAddresses = { 0x2559D96, 0x2559E36, 0x2559D9E, 0x2559DA6 };

        public static ulong TitleBackAddress = 0x553F0C;

        public static ulong TitleFlagAddress =
            !FileVersion.Contains("8") ? (ulong)0x1B0256 : (ulong)0x1B0216;
        public static ulong TitleButtonAddress = 0x255BECE;

        public static byte[] MagicStoreMemory;

        public static bool RoomLoad;

        public static ulong RoomAddress =
            !FileVersion.Contains("8") ? (ulong)0x1B08AA : (ulong)0x1B086A;
        public static ulong StoryFlagAddress = 0x444832;
        public static ulong LoadFlagAddress = 0x453B82;
        public static ulong DifficultyAddress = 0x444FFA;
        public static ulong CutsceneFlagAddress = 
            !FileVersion.Contains("8") ? (ulong)0x1C1C92 : (ulong)0x1C1C52 ;
        public static ulong BattleFlagAddress = 0x24AA5B6;
        public static ulong InventoryFlagAddress = 0x444F00;

        public static ulong ShortcutStartAddress =
            !FileVersion.Contains("8") ? (ulong)0x630AA : (ulong)0x6306A;

        public static byte[] LimiterInstruction =
            !FileVersion.Contains("8")
                ? new byte[] { 0x89, 0x1D, 0x62, 0x62, 0x96, 0x00 }
                : new byte[] { 0x89, 0x1D, 0xE2, 0x61, 0x96, 0x00 };
        public static byte[] LimiterRemoved = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };

        public static ulong InformationPointer = 0x25A5972;
        public static ulong SaveAddress = 0x442B62;

        public static byte SaveIterator;
        public static byte SaveWorld;
        public static byte SaveRoom;

        public static ulong[] LimitAddresses =
        {
            0x257257C,
            0x2571C0D,
            0x2572565,
            0x2571B80,
            0x2572534,
            0x2571D03
        };

        public static ulong[] SelectAddresses =
            !FileVersion.Contains("8")
                ? new ulong[] { 0x3AEAC1, 0x3AEBA5, 0x3AEC4C, 0x3AEBCD, 0x3AEC1C }
                : new ulong[] { 0x3AEC01, 0x3AECE5, 0x3AED8C, 0x3AED0D, 0x3AED5C };

        public static byte[][] SelectInstructions =
        {
            new byte[] { 0x89, 0x4B, 0x74 },
            new byte[] { 0x89, 0x53, 0x74 },
            new byte[] { 0x89, 0x7B, 0x74 },
            new byte[] { 0x89, 0x4B, 0x74 },
            new byte[] { 0x89, 0x43, 0x74 }
        };

        public static byte[] StoryFlagArray =
        {
            0x01,
            0x00,
            0xF0,
            0xFF,
            0xFF,
            0xFF,
            0xFF,
            0xFF,
            0xFF,
            0xFF,
            0xFF,
            0xDB,
            0xFF,
            0xFF,
            0xFF,
            0xFF,
            0xFF,
            0xFF,
            0x07,
            0x00,
            0x00,
            0x00,
            0x00,
            0x00,
            0x00,
            0xD0,
            0x05,
            0x08,
            0x01,
            0x00,
            0x00,
            0x81
        };

        public static string[] TitleStrings =
        {
            "Play Roxas' Story?",
            "YES{0x00}NO",
            "Play through Roxas' Story normally.",
            "                Skip Roxas' Story entirely.{0x02}{0x07}{0xFF}{0xFF}{0x00}{0x80}(You will miss important story elements if you do!)",
            "Roxas' Story"
        };

        public static string[] LimitStrings = { "Ars Arcanum", "Sonic Blade", "Ragnarok" };

        public static readonly string[] SaveStrings =
        {
            "Auto-Save",
            "Autosave functionality.",
            "Autosave functionality."
        };

        public static string[] AudioStrings =
        {
            "Audio Language",
            "English",
            "Japanese",
            "Switch between English and Japanese speech.\n{0x07}{0xFF}{0xFF}{0x00}{0x80}(Work in Progress! The world must be\nreloaded for the changes to take effect!){0x03}"
        };

        public static ulong[] MagicAddresses = new ulong[] { 0x24AA2CA, 0x24AA33A, 0x24A98EE };
    }
}
