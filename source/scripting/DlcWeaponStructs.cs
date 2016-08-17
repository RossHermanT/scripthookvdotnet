﻿using System;
using System.Runtime.InteropServices;
using GTA.Native;

namespace GTA
{
	[StructLayout(LayoutKind.Explicit, Size = 39*8)]
	public unsafe struct DlcWeaponData
	{
		[FieldOffset(0x00)] private int validCheck;

		[FieldOffset(0x08)] private int weaponHash;

		[FieldOffset(0x18)] private int weaponCost;

		[FieldOffset(0x20)] private int ammoCost;

		[FieldOffset(0x28)] private int ammoType;

		[FieldOffset(0x30)] private int defaultClipSize;

		[FieldOffset(0x38)] private fixed char name [16];

		[FieldOffset(0x78)] private fixed char desc [16];

		[FieldOffset(0xB8)] private fixed char simpleDesc [16]; //usually refers to "the " + name

		[FieldOffset(0xF8)] private fixed char upperCaseName [16];

		public bool IsValid
		{
			get { return !Function.Call<bool>(Native.Hash._IS_DLC_DATA_EMPTY, validCheck); }
		}

		public WeaponHash Hash
		{
			get { return (WeaponHash)weaponHash; }
		}

		public string DisplaySimpleDescription
		{
			get
			{
				fixed (char* ptr = simpleDesc)
				{
					return MemoryAccess.ReadString(new IntPtr(ptr));
				}
			}
		}
		public string LocalizedSimpleDescription
		{
			get
			{
				fixed (char* ptr = simpleDesc)
				{
					return Game.GetGXTEntry((ulong)ptr);
				}
			}
		}

		public string DisplayDescription
		{
			get
			{
				fixed (char* ptr = desc)
				{
					return MemoryAccess.ReadString(new IntPtr(ptr));
				}
			}
		}
		public string LocalizedDescription
		{
			get
			{
				fixed (char* ptr = desc)
				{
					return Game.GetGXTEntry((ulong)ptr);
				}
			}
		}

		public string DisplayName
		{
			get
			{
				fixed (char* ptr = name)
				{
					return MemoryAccess.ReadString(new IntPtr(ptr));
				}
			}
		}
		public string LocalizedName
		{
			get
			{
				fixed (char* ptr = name)
				{
					return Game.GetGXTEntry((ulong)ptr);
				}
			}
		}


		public string DisplayUpperName
		{
			get
			{
				fixed (char* ptr = upperCaseName)
				{
					return MemoryAccess.ReadString(new IntPtr(ptr));
				}
			}
		}
		public string LocalizedUpperName
		{
			get
			{
				fixed (char* ptr = upperCaseName)
				{
					return Game.GetGXTEntry((ulong)ptr);
				}
			}
		}
	}

	[StructLayout(LayoutKind.Explicit, Size = 22*8)]
	public unsafe struct DlcWeaponComponentData
	{
		[FieldOffset(0x00)] private int componentTypeHash;

		[FieldOffset(0x08)] private int bActiveByDefault;

		[FieldOffset(0x18)] private int componentHash;

		[FieldOffset(0x28)] private int componentCost;

		[FieldOffset(0x30)] private fixed char name [16];

		[FieldOffset(0x70)] private fixed char desc [16];

		public WeaponComponentHash Hash
		{
			get { return (WeaponComponentHash)componentHash; }
		}
		public string DisplayDescription
		{
			get
			{
				fixed (char* ptr = desc)
				{
					return MemoryAccess.ReadString(new IntPtr(ptr));
				}
			}
		}

		public string LocalizedDescription
		{
			get
			{
				fixed (char* ptr = desc)
				{
					return Game.GetGXTEntry((ulong)ptr);
				}
			}
		}

		public string DisplayName
		{
			get
			{
				fixed (char* ptr = name)
				{
					return MemoryAccess.ReadString(new IntPtr(ptr));
				}
			}
		}

		public string LocalizedName
		{
			get
			{
				fixed (char* ptr = name)
				{
					return Game.GetGXTEntry((ulong)ptr);
				}
			}
		}
	}

}
