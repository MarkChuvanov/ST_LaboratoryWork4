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

		public VersionRange GetVersionRange (Version version)
		{
			return null;
		}

		public override string ToString ()
		{
			return $"[({StartVersion}), ({FinalVersion})]";
		}
	}
}