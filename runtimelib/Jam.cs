using System.Runtime.CompilerServices;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace Jam
{
	public enum ActionsFlags
	{
		None = 0,
		Updated = 1 << 0,
		Together = 1 << 1,
		Ignore = 1 << 2,
		Quietly = 1 << 3,
		Piecemeal = 1 << 4,
		Existing = 1 << 5,
		Response = 1 << 6,
		MaxLine = 1 << 7,
		Lua = 1 << 8,
		MaxTargets = 1 << 9,
		WriteFile = 1 << 10,
		ScreenOutput = 1 << 11,
		RemoveEmptyDirs = 1 << 12
	}
		

#if EMBEDDED_MODE
	public class Interop
	{
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public static extern string[] InvokeRule(string rulename, string[][] param);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		[DllImport("__Internal")]

		public static extern void MakeActions(string name,string actions,int flags, int maxTargets, int maxLines);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public static extern void SetVar(string name,string[] value);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public static extern string[] GetVar(string name);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public static extern void SetSetting(string name, string[] targets, string[] values);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public static extern string[] GetSetting(string name, string targets);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		private static extern string[] RegisterRuleInternal(string name, Object includeFunction);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public static extern void Include(string file);

		public static string[] RegisterInclude(string name, Func<string[][],string[]> includeFunction)
		{
			return RegisterRuleInternal (name, includeFunction);
		}

		public static string[] RegisterRule(string name, Func<string[][],string[]> includeFunction)
		{
			return RegisterRuleInternal (name, includeFunction);
		}
	}
#endif
}
