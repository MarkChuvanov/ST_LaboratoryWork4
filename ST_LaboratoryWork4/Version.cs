using System;

namespace ST_LaboratoryWork4
{
	public class Version
	{
		internal int Major { get; set; }
		internal int Minor { get; set; }
		internal int Patch { get; set; }
		internal string PreRelease { get; set; }

		public Version (string version)
		{
			if (!IsCorrect(version))
			{
				throw new ArgumentException("Значение версии не может быть распознано корректно");
			}
			string[] parameters = version.Split('-');
			string[] versions = parameters[0].Split('.');
			Major = int.Parse(versions[0]);
			if (versions.Length == 2)
			{
				Minor = int.Parse(versions[1]);
			}
			if (versions.Length == 3)
			{
				Minor = int.Parse(versions[1]);
				Patch = int.Parse(versions[2]);
			}
			if (parameters.Length == 2)
			{
				PreRelease = parameters[1];
			}
		}

		internal Version (int major, int minor, int patch, string preRelease)
		{
			Major = major;
			Minor = minor;
			Patch = patch;
			PreRelease = preRelease;
		}

		private static bool IsCorrect (string version)
		{
			if (System.Text.RegularExpressions.Regex.IsMatch(version, @"[\d*\.?]+-?[\w*\.?\w*]*"))
			{
				return true;
			}
			return false;
		}

		public static bool operator > (Version version1, Version version2)
		{
			return IsMore(version1, version2);
		}

		public static bool operator < (Version version1, Version version2)
		{
			return !IsMore(version1, version2);
		}

		private static bool IsMore (Version v1, Version v2)
		{
			int release1 = v1.Major * 100 + v1.Minor * 10 + v1.Patch;
			int release2 = v2.Major * 100 + v2.Minor * 10 + v2.Patch;
			if (release1 > release2)
			{
				return true;
			}
			else if (release1 == release2)
			{
				if (v1.PreRelease == null && v2.PreRelease != null)
				{
					return true;
				}
				if (v1.PreRelease != null & v2.PreRelease != null && string.Compare(v1.PreRelease, v2.PreRelease) > 0)
				{
					return true;
				}
			}
			return false;
		}

		public static bool operator >= (Version version1, Version version2)
		{
			return IsMoreOrEqual(version1, version2);
		}

		private static bool IsMoreOrEqual (Version v1, Version v2)
		{
			int release1 = v1.Major * 100 + v1.Minor * 10 + v1.Patch;
			int release2 = v2.Major * 100 + v2.Minor * 10 + v2.Patch;
			if (release1 > release2)
			{
				return true;
			}
			else if (release1 == release2)
			{
				if (v1.PreRelease == null)
				{
					return true;
				}
				if (v1.PreRelease != null & v2.PreRelease != null && string.Compare(v1.PreRelease, v2.PreRelease) == 0)
				{
					return true;
				}
			}
			return false;
		}

		public static bool operator <= (Version version1, Version version2)
		{
			return IsLessOrEqual(version1, version2);
		}

		private static bool IsLessOrEqual (Version v1, Version v2)
		{
			int release1 = v1.Major * 100 + v1.Minor * 10 + v1.Patch;
			int release2 = v2.Major * 100 + v2.Minor * 10 + v2.Patch;
			if (release1 > release2)
			{
				return false;
			}
			else
			{
				if (release1 == release2)
				{
					if (v1.PreRelease == null & v2.PreRelease != null)
					{
						return false;
					}
					if (v1.PreRelease != null & v2.PreRelease != null && string.Compare(v1.PreRelease, v2.PreRelease) < 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		public static bool operator == (Version version1, Version version2)
		{
			return IsEqual(version1, version2);
		}

		public static bool operator != (Version version1, Version version2)
		{
			return !IsEqual(version1, version2);
		}

		private static bool IsEqual (Version v1, Version v2)
		{
			if (v1.ToString() == v2.ToString())
			{
				return true;
			}
			return false;
		}

		public override string ToString ()
		{
			if (PreRelease != null)
			{
				return $"{Major}.{Minor}.{Patch}-{PreRelease}";
			}
			return $"{Major}.{Minor}.{Patch}";
		}
	}
}