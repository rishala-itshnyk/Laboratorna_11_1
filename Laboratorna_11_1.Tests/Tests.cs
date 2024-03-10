namespace Laboratorna_11_1.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void ProcessAndPrintTest()
    {
        string inputFileName = "testInput.dat";
        string outputFileName = "testOutput.dat";

        GenerateTestData(inputFileName);

        Program.Process(inputFileName);
        Program.Print();

        Assert.IsTrue(File.Exists("result.dat"));

        using (BinaryReader reader = new BinaryReader(File.OpenRead("result.dat")))
        {
            Assert.AreEqual(4, reader.ReadInt32());
            Assert.AreEqual(9, reader.ReadInt32());
        }
    }

    private void GenerateTestData(string fileName)
    {
        using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileName)))
        {
            writer.Write(2);
            writer.Write(4);
            writer.Write(9);
            writer.Write(16);
            writer.Write(25);
        }
    }
}