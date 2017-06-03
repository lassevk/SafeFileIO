using System;
using System.IO;

using NUnit.Framework;

namespace SafeFileIO.Tests
{
    [TestFixture]
    public class SafeFileTests
    {
        [Test]
        public void TryDelete_FileDoesNotExist_ReturnsFalse()
        {
            var g = Guid.NewGuid();
            var filename = Path.Combine(Path.GetTempPath(), g.ToString() + ".txt");

            var result = SafeFile.TryDelete(filename);

            Assert.That(result, Is.False);
        }
    }
}
