using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_LaboratoryWork4
{
	class VersionRange
	{
		public Version StartVersion { get; }
		public Version FinalVersion { get; }

		public VersionRange (Version version1, Version version2)
		{
			StartVersion = version1;
			FinalVersion = version2;
		}

		public VersionRange (string version1, string version2)
		{
			StartVersion = new Version(version1);
			FinalVersion = new Version(version2);
		}

		public bool Contains (Version version)
		{
			if (StartVersion <= version && version <= FinalVersion)
			{
				return true;
			}
			return false;
		}

		public bool Contains (VersionRange versionRange)
		{
			if (StartVersion <= versionRange.StartVersion && versionRange.FinalVersion <= FinalVersion)
			{
				return true;
			}
			return false;
		}

		public static VersionRange GetVersionRange (Version version)
		{
			int versionValue = version.Major * 100 + version.Minor * 10 + version.Patch;
			int finalVersionValue;
			if (version.PreRelease == null)
			{
				if (versionValue % 100 == 0)
				{
					finalVersionValue = versionValue + 100;
				}
				else if (versionValue % 10 == 0)
				{
					finalVersionValue = versionValue + 10;
				}
				else
				{
					finalVersionValue = (versionValue / 10 + 1) * 10;
				}
			}
			else
			{
				finalVersionValue = versionValue + 1;
			}
			return new VersionRange(version, new Version(finalVersionValue / 100, finalVersionValue % 100 / 10, finalVersionValue % 10, null));
		}

		public static bool operator == (VersionRange versionRange1, VersionRange versionRange2)
		{
			return IsEqual(versionRange1, versionRange2);
		}

		public static bool operator != (VersionRange versionRange1, VersionRange versionRange2)
		{
			return IsEqual(versionRange1, versionRange2);
		}

		private static bool IsEqual(VersionRange r1, VersionRange r2)
		{
			return r1.ToString() == r2.ToString();
		}

		public override string ToString ()
		{
			return $"[({StartVersion}), ({FinalVersion})]";
		}
	}
}