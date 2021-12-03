using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_LaboratoryWork4
{
	[TestFixture]
	public class VersionRangeTest
	{
		[Test]
		public void ToStringTest ()
		{
			Assert.AreEqual("[(1.0.0), (1.2.2)]", new VersionRange("1.0.0", "1.2.2").ToString());
		}

		[Test]
		public void ContainsVersionTest ()
		{
			VersionRange versionRange = new("1.0.0", "1.1.2");
			Assert.IsTrue(versionRange.Contains(new Version("1.0.1")));
			Assert.IsTrue(versionRange.Contains(new Version("1.0.2-alpha")));
			Assert.IsFalse(versionRange.Contains(new Version("1.1.3")));
		}

		[Test]
		public void ContainsVersionRangeTest ()
		{
			VersionRange versionRange = new("1.0.0", "2.1.2");
			Assert.IsTrue(versionRange.Contains(new VersionRange("1.0.5", "2.0.0")));
			Assert.IsTrue(versionRange.Contains(new VersionRange("1.5.5", "1.8.0-alpha.2")));
			Assert.IsFalse(versionRange.Contains(new VersionRange("2.0.0", "3.5.0")));
		}

		[Test]
		public void GetVersiongRangeFromVersionTest ()
		{
			Assert.IsTrue(new VersionRange("1.0.0", "2.0.0") == VersionRange.GetVersionRange(new Version("1")));
			Assert.IsTrue(new VersionRange("1.1.0", "1.2.0") == VersionRange.GetVersionRange(new Version("1.1")));
			Assert.IsTrue(new VersionRange("1.1.1", "1.2.0") == VersionRange.GetVersionRange(new Version("1.1.1")));
			Assert.IsTrue(new VersionRange("1.0.0-alpha", "1.0.1") == VersionRange.GetVersionRange(new Version("1.0.0-alpha")));
		}

		[Test]
		public void GetVersionRangeFromStringTest ()
		{
			Assert.IsTrue(new VersionRange("1.0.0", "2.0.0") == VersionRange.GetVersionRange(("~1")));
			Assert.Throws<ArgumentException>(() =>
			{
				bool metka = new VersionRange("1.0.0", "2.0.0") == VersionRange.GetVersionRange(("1"));
			});
		}
	}
}