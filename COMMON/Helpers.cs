/*
==================================================
    KINGDOM HEARTS - RE:FINED COMMON FILE!
       COPYRIGHT TOPAZ WHITELOCK - 2022
 LICENSED UNDER DBAD. GIVE CREDIT WHERE IT'S DUE! 
==================================================
*/

using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Security.Principal;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReFined
{
    public static class Helpers
    {
	    static string _logFileName = "";

		public static void InitConfig()
		{			
			if (!File.Exists("reFined.ini"))
			{
				var _outIni = new string[]
				{
					"[General]",
                    "# Options: infobar, silent, off",
                    "autoSave = infobar",
					"discordRPC = true",
					"autoAttack = false",
					"",
					"# Options: vanilla, remastered",
					"musicMode = remastered",
					"",
					"# Options: classic, special",
					"heartlessColors = classic",
					"",
					"# Options: english, japanese",
					"audioLanguage = english",
					"",
					"# Options: true = Controller, false = Keyboard, auto = Autodetect",
					"controllerPrompt = auto",
					"",
					"[Kingdom Hearts]",
					"battleChests = true",
					"",
					"[Kingdom Hearts II]",
					"festivityEngine = true",
					"driveShortcuts = true",
					"",
					"# Options: retry, continue",
					"deathPrompt = retry",
					"resetPrompt = true",
					"",
					"# Options: sonic, arcanum, raid, ragnarok",
					"# Order: [CONFIRM], TRI, SQU, [JUMP]",
					"# Duplicates are allowed. All 4 slots must be filled.",
					"limitShortcuts = [sonic, arcanum, raid, ragnarok]"
				};

				File.WriteAllLines("reFined.ini", _outIni);
			}

			else
			{
				var _fileRead = File.ReadAllText("reFined.ini");

				if (!_fileRead.Contains("heartlessColors"))
				{
					File.Delete("reFined.ini");
					InitConfig();
				}
				
				else
				{
					var _configIni = new TinyIni("reFined.ini");

                    var _indFetch = _configIni.Read("autoSave", "General");
                    Variables.saveToggle = (_indFetch == "silent" ? (byte)1 : (_indFetch == "infobar" ? (byte)0 : (byte)2));
                    Variables.rpcToggle = Convert.ToBoolean(_configIni.Read("discordRPC", "General"));
					Variables.attackToggle = Convert.ToBoolean(_configIni.Read("autoAttack", "General"));
					
					Variables.vanillaMusic = _configIni.Read("musicMode", "General") == "vanilla" ? true : false;
					Variables.vanillaEnemy = _configIni.Read("heartlessColors", "General") == "classic" ? true : false;

					var _contValue = _configIni.Read("controllerPrompt", "General");
                    Variables.autoController = (_contValue == "keyboard" ? (byte)1 : (_indFetch == "controller" ? (byte)0 : (byte)2));

					if (_configIni.KeyExists("debugMode", "General"))
						Variables.devMode = Convert.ToBoolean(_configIni.Read("debugMode", "General"));
				}
			}
		}

		public static void Log(string Input, byte Type)
		{
			try
			{
                var _documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var _logDir = Path.Combine(_documentsPath, "Kingdom Hearts/Logs");

                var _formatStr = "{0}{1}: {2}";

				var _dateStr = DateTime.Now.ToString("dd-MM-yyyy");
				var _timeStr = "[" + DateTime.Now.ToString("hh:mm:ss") + "] ";

				var _session = 1;

				var _typeStr = "";

				if (_logFileName == "")
				{
					_logFileName = "ReFined-" + _dateStr + ".txt";

					FILE_CHECK:
					if (File.Exists(_logFileName))
					{
						_logFileName = "ReFined-" + _dateStr + "_SESSION_" + _session + ".txt";
						_session++;

						goto FILE_CHECK;
					}
				}

				switch(Type)
				{
					case 0:
						_typeStr = "MESSAGE";
                        break;

					case 1:
						_typeStr = "WARNING";
                        break;

					case 2:
						_typeStr = "ERROR";
                        break;
				}

				using (StreamWriter _write = File.AppendText(Path.Combine(_logDir, _logFileName)))
					_write.WriteLine(String.Format(_formatStr, _timeStr, _typeStr, Input));

				if (Variables.devMode)
					Console.WriteLine(String.Format(_formatStr, _timeStr, _typeStr, Input));
			}

			catch (Exception) {}
		}

		public static void LogException(Exception Input)
		{
			try
			{
				var _formatStr = "[{0}] {1}";

				var _dateStr = DateTime.Now.ToString("dd-MM-yyyy");
				var _timeStr = DateTime.Now.ToString("hh:mm:ss");

				var _session = 1;

				if (_logFileName == "")
				{
					_logFileName = "ReFined-" + _dateStr + ".txt";

					FILE_CHECK:
					if (File.Exists(_logFileName))
					{
						_logFileName = "ReFined-" + _dateStr + "SESSION_" + _session + ".txt";
						_session++;

						goto FILE_CHECK;
					}
				}

				var _exString = Input.ToString().Replace("   ", "").Replace(System.Environment.NewLine, " ");

				using (StreamWriter _write = File.AppendText(_logFileName))
					_write.WriteLine(String.Format(_formatStr, _timeStr, _exString));

				if (Variables.devMode)
					Console.WriteLine(String.Format(_formatStr, _timeStr, _exString));
			}

			catch (Exception) {}
		}
    }
}
