using System;
using System.IO;

using NUnit.Framework;

namespace SafeFileIO.Tests
{
    [TestFixture]
    public class SafeFileTests
    {
        [Test]
        public void TryDelete_NullFilename_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SafeFile.TryDelete(null));
        }

        [Test]
        public void TryDelete_FileDoesNotExist_ReturnsTrue()
        {
            var g = Guid.NewGuid();
            var filename = Path.Combine(Path.GetTempPath(), g.ToString() + ".txt");

            var result = SafeFile.TryDelete(filename);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TryDelete_FileExistsButIsInUse_ReturnsFalse()
        {
            var g = Guid.NewGuid();
            var filename = Path.Combine(Path.GetTempPath(), g.ToString() + ".txt");

            using (File.Create(filename))
            {
                var result = SafeFile.TryDelete(filename);

                Assert.That(result, Is.False);
            }

            File.Delete(filename);
        }
    }
}
