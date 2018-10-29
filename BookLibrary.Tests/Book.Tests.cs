using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        [TestCase("Jon Skeet, C# in Depth, 2019, \"Manning\"", "ATYPh", "C# in Depth", "Jon Skeet", "2019", "\"Manning\"", "4", "900", "40$")]
        [TestCase("Jon Skeet, C# in Depth, 2019", "ATY", "C# in Depth", "Jon Skeet", "2019", "\"Manning\"", "4", "900", "40$")]
        [TestCase("Jon Skeet, C# in Depth", "AT", "C# in Depth", "Jon Skeet", "2019", "\"Manning\"", "4", "900", "40$")]
        [TestCase("C# in Depth", "T", "C# in Depth", "Jon Skeet", "2019", "\"Manning\"", "4", "900", "40$")]
        [TestCase("C# in Depth, 2019, \"Manning\"", "TYPh", "C# in Depth", "Jon Skeet", "2019", "\"Manning\"", "4", "900", "40$")]
        public void ToString_Test(string expected, string format, string title, string author, string year, 
                                string publishingHous, string edition, string pages, string price)
        {
            Book book = new Book("C# in Depth", "Jon Skeet", "2019", "\"Manning\"", "4", "900", "40$");
            Assert.AreEqual(expected, book.ToString(format));            
        }
    }
}
