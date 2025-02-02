/*
==================================================
   KINGDOM HEARTS - RE:FINED FOR II FM!
     COPYRIGHT TOPAZ WHITELOCK - 2022
LICENSED UNDER DBAD. GIVE CREDIT WHERE IT'S DUE! 
==================================================
*/

using System.IO;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using DiscordRPC;
using Binarysharp.MSharp;

namespace ReFined
{
    public class Variables
    {
        //
        // CONFIG VARIABLES
        //
        // Variables that will be read from a config file to tell Re:Fined what to do.
        //

        public static bool DEV_MODE;
        public static bool ATTACK_TOGGLE;
        public static bool DISCORD_TOGGLE = true;

        public static bool RESET_PROMPT = true;
        public static ushort RESET_COMBO = 0x0003;

        public static byte SAVE_MODE = 0x00;

        public static bool RATIO_ADJUST;
        public static bool FORM_SHORTCUT = true;

        public static byte AUDIO_MODE = 0x00;
        public static bool ENEMY_VANILLA = true;
        public static bool MUSIC_VANILLA = false;

        public static bool RETRY_DEFAULT = true;
        public static byte CONTROLLER_MODE = 0x00;

        public static string LIMIT_SHORTS;

        //
        // RESOURCE LIBRARY
        //
        // Reserved for static resources, or initialization of APIs
        //

        public static MemorySharp SharpHook;
        public static DiscordRpcClient DiscordClient = new DiscordRpcClient("833511404274974740");

        public static string[] BOSSObjentry =
        {
            "B_BB100",
            "B_BB100_GM",
            "B_BB100_TSURU",
            "B_CA000",
            "B_CA050",
            "B_CA050_GM",
            "B_LK120",
            "B_LK120_GM",
            "B_MU120",
            "B_MU120_GM",
        };

        public static string[] ENEMYObjentry =
        {
            "M_EX010",
            "M_EX010_NM",
            "M_EX050",
            "M_EX060",
            "M_EX200",
            "M_EX200_NM",
            "M_EX500",
            "M_EX500_GM",
            "M_EX500_HB",
            "M_EX500_HB_GM",
            "M_EX500_NM",
            "M_EX510",
            "M_EX520",
            "M_EX520_AL",
            "M_EX530",
            "M_EX540",
            "M_EX550",
            "M_EX560",
            "M_EX570",
            "M_EX590",
            "M_EX620",
            "M_EX620_AL",
            "M_EX630",
            "M_EX640",
            "M_EX650",
            "M_EX670",
            "M_EX690",
            "M_EX710",
            "M_EX720",
            "M_EX730",
            "M_EX750",
            "M_EX750_NM",
            "M_EX780",
            "M_EX790",
            "M_EX790_HALLOWEEN",
            "M_EX790_HALLOWEEN_NM"
        };

        public static Dictionary<string, short> LMTDictionary = new Dictionary<string, short>()
        {
            { "ragnarok", 0x02AB },
            { "arcanum", 0x02BD },
            { "raid", 0x02C0 },
            { "sonic", 0x02BA }
        };

        //
        // ALTERED VARIABLES
        //
        // Variables that can be altered reside here.
        //

        public static bool Initialized = false;

        public static Task DCTask;
        public static Task ASTask;
        public static Task CRTask;
        public static CancellationToken Token;
        public static CancellationTokenSource Source;

        //
        // ADDRESSES
        //
        // All of the necessary address values.
        //

        public static ulong ADDR_Reset = 0x0553F0C;
        public static ulong ADDR_Input = 0x01ACF3B;
        public static ulong ADDR_Confirm = 0x0365520;

        public static ulong ADDR_Area = 0x01B086A;
        public static ulong ADDR_Title = 0x01B0216;
        public static ulong ADDR_LoadFlag = 0x0453B82;
        public static ulong ADDR_MenuType = 0x03999C6;
        public static ulong ADDR_PauseFlag = 0x0554092;
        public static ulong ADDR_MenuSelect = 0x039C242;
        public static ulong ADDR_MenuActive = 0x0399952;
        public static ulong ADDR_BattleFlag = 0x24AA5B6;
        public static ulong ADDR_FinishFlag = 0x0572672;
        public static ulong ADDR_SubMenuType = 0x06877DE;
        public static ulong ADDR_CutsceneFlag = 0x01C1C52;

        public static ulong ADDR_Config = 0x446D06;
        public static ulong ADDR_NewGame = 0x5B6AC2;
        public static ulong ADDR_SaveData = 0x442B62;

        public static ulong ADDR_AbilityStart = 0x4450A6;

        public static ulong ADDR_Framerate = 0x036550C;
        public static ulong ADDR_Framelimiter = 0x0553EBA;
        public static ulong ADDR_ControllerMode = 0x25DDFFA;

        public static ulong ADDR_GameTime = 0x0444FA6;
        public static ulong ADDR_PlayerHP = 0x24BC74A;
        public static ulong ADDR_PlayerForm = 0x0446086;
        public static ulong ADDR_PlayerLevel = 0x0445061;
        public static ulong ADDR_GameDifficulty = 0x0444FFA;

        public static ulong ADDR_MagicIndex = 0x24A98EE;
        public static ulong ADDR_MagicCommands = 0x24AA33A;

        public static ulong ADDR_MagicLV1 = 0x4460F6;
        public static ulong ADDR_MagicLV2 = 0x446131;

        public static ulong ADDR_LimitShortcut = 0x006306A;

        public static ulong ADDR_TitleOptionCount = 0x05B68A2;
        public static ulong ADDR_TitleOptionSelect = 0x05B6896;

        public static ulong ADDR_StoryFlag = 0x444832;
        public static ulong ADDR_InventoryFlag = 0x444F00;

        public static ulong ADDR_ConfigMenu = 0x2BBAB2;
        public static ulong ADDR_NewGameMenu = 0x2BCAB2;

        public static ulong ADDR_ActionExe = 0x24F5B48;
        public static ulong ADDR_ReactionID = 0x24AA314;

        public static ulong ADDR_MusicPath = 0x04E6B6;
        public static ulong ADDR_PAXFormatter = 0x0061F92;
        public static ulong ADDR_BTLFormatter = 0x005F83A;
        public static ulong ADDR_ANBFormatter = 0x00529C2;
        public static ulong ADDR_EVTFormatter = 0x0052A32;

        public static ulong ADDR_ObjentryBASE = 0x24BE682;

        public static ulong[] ADDR_MPSEQD = { 0x4A03C6, 0x4A0376, 0x4A035A, 0x4A038A };

        //
        // POINTERS
        //
        // Addresses for the pointers we need.
        //

        public static ulong PINT_MagicMenu = 0x24AA2CA;

        public static ulong PINT_SubMenuOptionSelect = 0x687E6A;
        public static ulong PINT_SubOptionSelect = 0x39BAFA;

        public static ulong PINT_ConfigMenu = 0x6892E2;
        public static ulong PINT_SystemMSG = 0x24AA82A;

        public static ulong PINT_GameOver = 0x68863A;
        public static ulong PINT_GameOverOptions = 0x24AA512;

        public static ulong PINT_EnemyInfo = 0x24A5F22;
        public static ulong PINT_SaveInformation = 0x25A5972;

        //
        // RPC ASSET LIBRARY
        //
        // Everything DiscordRPC uses (except for the RPC itself) resides here.
        //

        public static string[] DICTIONARY_BTL = { "safe", "mob", "boss" };
        public static string[] DICTIONARY_WRL = { "", "", "tt", "", "hb", "bb", "he", "al", "mu", "po", "lk", "lm", "dc", "wi", "nm", "wm", "ca", "tr", "eh" };
        public static string[] DICTIONARY_CPS = { "cup_pp", "cup_cerb", "cup_titan", "cup_god", "cup_hades" };
        public static string[] DICTIONARY_FRM = { "None", "Valor", "Wisdom", "Limit", "Master", "Final", "Anti" };
        public static string[] DICTIONARY_MDE = { "Beginner Mode", "Standard Mode", "Proud Mode", "Critical Mode" };

        //
        // INSTRUCTION ADDRESSES
        //
        // Addresses for instructions are here.
        //

        public static ulong ADDR_ShortListFilterINST = 0x349718;
        public static ulong ADDR_ShortEquipFilterINST = 0x3C1A46;
        public static ulong ADDR_ShortCategoryFilterINST = 0x35924F;
        public static ulong ADDR_ShortIconAssignINST = 0x2E99CA;

        public static ulong ADDR_FramelimiterINST = 0x152220;
        public static ulong[] ADDR_CMDSelectINST = { 0x3AEC01, 0x3AECE5, 0x3AED8C, 0x3AED0D, 0x3AED5C };

        public static ulong ADDR_WarpINST = 0x150782;
        public static ulong ADDR_InventoryINST = 0x39DEC4;

        public static ulong ADDR_SaveEffectINST = 0x405FEB;
        public static ulong ADDR_ControllerINST = 0x4E80DA;

        //
        // INSTRUCTIONS
        // 
        // We store the actual instructions here.
        //

        public static byte[] INST_FrameLimiter = { 0x89, 0x1D, 0xE2, 0x61, 0x96, 0x00 };


        public static byte[][] INST_CMDSelect =
        {
            new byte[] { 0x89, 0x4B, 0x74 },
            new byte[] { 0x89, 0x53, 0x74 },
            new byte[] { 0x89, 0x7B, 0x74 },
            new byte[] { 0x89, 0x4B, 0x74 },
            new byte[] { 0x89, 0x43, 0x74 }
        };

        public static byte[][] INST_ShortListFilter =
        {
            new byte[] { 0xEB, 0x4E, 0x90, 0x90 },
            new byte[] { 0x81, 0xCB, 0x00, 0x00, 0x24, 0x00 },
            new byte[] { 0xEB, 0xAA }
        };

        public static byte[][] INST_ShortEquipFilter =
        {
            new byte[] { 0xEB, 0x1B, 0x90, 0x90, 0x90, 0x90, 0x90 },
            new byte[] { 0x80, 0xF9, 0x15, 0x74, 0xF2 },
            new byte[] { 0x31, 0xC0, 0x48, 0x83, 0xC4, 0x28, 0xC3 }
        };

        public static byte[][] INST_ShortIconAssign =
        {
            new byte[] { 0xEB, 0x19 },
            new byte[] { 0x3C, 0x0B, 0x75, 0x02, 0xB0 },
            new byte[] { 0x88, 0x47, 0x01, 0xEB, 0xDC }
        };

        public static byte[] INST_RoomWarp = { 0xE8, 0x59, 0x00, 0x00, 0x00 };
        public static byte[] INST_InvRevert = { 0x48, 0x8D, 0x15, 0xB5, 0xAD, 0x65, 0x02 };


        //
        // VALUE DUMP
        //
        // The values themselves, which will be written to shit, are stored here.
        // 

        public static List<ushort[]> ARRY_ContinueOptions = new List<ushort[]>
        {
            new ushort[] { 0x0002, 0x0002, 0x8AB0, 0x0001, 0x8AAF, 0x0000, 0x0000, 0x0000, 0x0000 }, // No Retry
            new ushort[] { 0x0004, 0x0002, 0x8AB1, 0x0002, 0x01DE, 0x0002, 0x8AB0, 0x0001, 0x8AAF }, // Retry Default
            new ushort[] { 0x0004, 0x0002, 0x8AB0, 0x0002, 0x8AB1, 0x0002, 0x01DE, 0x0001, 0x8AAF }, // Continue Default
        };

        public static ushort[] VALUE_ConfigTitle = { 0x3738, 0x3739, 0x373A, 0x4E32 };
        public static ushort[] VALUE_ConfigDescription = { 0x373B, 0x373C, 0x373D, 0x4E31 };
        
        public static byte[] VALUE_StoryFlag = { 0x01, 0x00, 0xF0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xDB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD0, 0x05, 0x08, 0x01, 0x00, 0x00, 0x81 };

        public static ushort[] VALUE_ConfigAudio = new ushort[] { 0x0003, 0x01BD, 0x01C4, 0x01D9, 0x01C5, 0x0000, 0x01D0, 0x01DA, 0x01D1, 0x0000 };

        public static List<ushort[]> ARRY_ConfigMenu = new List<ushort[]>
        {
            new ushort[] { 0x0002, 0xB717, 0xB71E, 0xB71F, 0x0000, 0x0000, 0xB720, 0xB721, 0x0000, 0x0000  },
            new ushort[] { 0x0002, 0xC2F5, 0xC2F8, 0xC2F9, 0x0000, 0x0000, 0xC2FA, 0xC2FB, 0x0000, 0x0000  },
            new ushort[] { 0x0002, 0xC2F6, 0xC2FC, 0xC2FD, 0x0000, 0x0000, 0xC2FE, 0xC2FF, 0x0000, 0x0000  },
            new ushort[] { 0x0003, 0xC2F7, 0xC302, 0xC300, 0xC301, 0x0000, 0xC305, 0xC303, 0xC304, 0x0000  },
            new ushort[] { 0x0002, 0xB719, 0xB726, 0xB727, 0x0000, 0x0000, 0xB728, 0xB729, 0x0000, 0x0000  },
            new ushort[] { 0x0003, 0x01BC, 0x01C1, 0x01C2, 0x01C3, 0x0000, 0x01CD, 0x01CE, 0x01CF, 0x0000  },
            new ushort[] { 0x0002, 0x01BD, 0x01C4, 0x01C5, 0x0000, 0x0000, 0x01D0, 0x01D1, 0x0000, 0x0000  },
            new ushort[] { 0x0002, 0x01BE, 0x01C6, 0x01C7, 0x0000, 0x0000, 0x01D2, 0x01D3, 0x01D4, 0x0000  },
            new ushort[] { 0x0002, 0x01BF, 0x01C8, 0x01C9, 0x0000, 0x0000, 0x01D4, 0x01D5, 0x0000, 0x0000  },
            new ushort[] { 0x0003, 0x01C0, 0x01CA, 0x01CB, 0x01CC, 0x0000, 0x01D6, 0x01D7, 0x01D8, 0x0000  },
            new ushort[] { 0x0002, 0xB71A, 0xB72A, 0xB752, 0x0000, 0x0000, 0xB72C, 0xB72D, 0x0000, 0x0000  },
            new ushort[] { 0x0002, 0xB71C, 0xB734, 0xB735, 0x0000, 0x0000, 0xB736, 0xB737, 0x0000, 0x0000  },
            new ushort[] { 0x0001, 0xB71D, 0xB738, 0xB739, 0xB73A, 0xCE30, 0xB73B, 0xB73C, 0xB73D, 0xCE31  }
        };

        public static uint[] VALUE_NewGameAudio = new uint[] { 0x00000002, 0x0000E006, 0xFFFFFFFF, 0x000081C4, 0x000081D9, 0x000081C5, 0xFFFFFFFF, 0x000081D0, 0x000081DA, 0x000081D1, 0xFFFFFFFF };


        public static List<uint[]> ARRY_NewGameMenu = new List<uint[]>
        {
            new uint[] { 0x00000004, 0x0000C330, 0x0000C380, 0x0000C331, 0x0000C332, 0x0000C333, 0x0000CE33, 0x0000C334, 0x0000C335, 0x0000C336, 0x0000CE34 }, // Difficulty
            new uint[] { 0x00000002, 0x0000C337, 0x0000C381, 0x0000C338, 0x0000C339, 0xFFFFFFFF, 0xFFFFFFFF, 0x0000C33A, 0x0000C33B, 0xFFFFFFFF, 0xFFFFFFFF }, // Vibration
            new uint[] { 0x00000003, 0x0000E005, 0xFFFFFFFF, 0x000081C1, 0x000081C2, 0x000081C3, 0xFFFFFFFF, 0x000081CD, 0x000081CE, 0x000081CF, 0xFFFFFFFF }, // Autosave
            new uint[] { 0x00000002, 0x0000E006, 0xFFFFFFFF, 0x000081C4, 0x000081C5, 0x00000000, 0xFFFFFFFF, 0x000081D0, 0x000081D1, 0x00000000, 0xFFFFFFFF }, // Audio Language
            new uint[] { 0x00000002, 0x0000E007, 0xFFFFFFFF, 0x000081C7, 0x000081C6, 0xFFFFFFFF, 0xFFFFFFFF, 0x000081D3, 0x000081D2, 0xFFFFFFFF, 0xFFFFFFFF }, // Background Music
            new uint[] { 0x00000002, 0x0000E008, 0xFFFFFFFF, 0x000081C9, 0x000081C8, 0xFFFFFFFF, 0xFFFFFFFF, 0x000081D5, 0x000081D4, 0xFFFFFFFF, 0xFFFFFFFF }, // Heartless Palette
            new uint[] { 0x00000003, 0x0000E009, 0xFFFFFFFF, 0x000081CA, 0x000081CB, 0x000081CC, 0xFFFFFFFF, 0x000081D6, 0x000081D7, 0x000081D8, 0xFFFFFFFF }, // Controller Prompts
            new uint[] { 0x00000002, 0x0000E000, 0xFFFFFFFF, 0x0000E001, 0x0000E002, 0xFFFFFFFF, 0xFFFFFFFF, 0x0000E003, 0x0000E004, 0xFFFFFFFF, 0xFFFFFFFF }, // Skip Roxas
        };

        public static byte[] HASH_SwapAudio = { 0x26, 0x72, 0x0C, 0xDE, 0xD5, 0x68, 0x39, 0x0F, 0x18, 0x5A, 0x98, 0x8E, 0xD0, 0x8C, 0x90, 0xC5 };
        public static byte[] HASH_SwapExtra = { 0x79, 0x57, 0x31, 0x9B, 0xB3, 0xDC, 0x23, 0x1D, 0x8D, 0xF5, 0x54, 0x23, 0x08, 0xB8, 0x03, 0xA1 };
        public static byte[] HASH_SwapEnemy = { 0x82, 0x99, 0xD3, 0x20, 0xC6, 0x70, 0xC4, 0x9F, 0x7C, 0x02, 0x94, 0x06, 0xAC, 0x19, 0x53, 0xBD };
        public static byte[] HASH_SwapMusic = { 0x84, 0x7F, 0x72, 0x02, 0x21, 0xE0, 0xBC, 0x89, 0x70, 0xEC, 0x27, 0xE2, 0x25, 0x2D, 0x2E, 0x26 };


        public static byte[] VALUE_MPSEQD = { 0x7A, 0x78, 0x18, 0x79 };

        //
        // ENUM AREA
        //
        // The various enums which will be used.
        //

        public enum CONFIG_BITWISE : ushort
        {
            OFF = 0x0000,
            VIBRATION = 0x0001,
            AUTOSAVE_SILENT = 0x0002,
            AUTOSAVE_INDICATOR = 0x0004,
            NAVI_MAP = 0x0008,
            FIELD_CAM = 0x0010,
            MUSIC_VANILLA = 0x0020,
            COMMAND_KH2 = 0x0040,
            CAMERA_H = 0x0080,
            CAMERA_V = 0x0100,
            SUMMON_PARTIAL = 0x0200,
            SUMMON_FULL = 0x0400,
            AUDIO_JAPANESE = 0x0800,
            AUDIO_OTHER = 0x1000,
            PROMPT_CONTROLLER = 0x2000,
            PROMPT_KEYBOARD = 0x4000,
            HEARTLESS_VANILLA = 0x8000
        }
    }
}
