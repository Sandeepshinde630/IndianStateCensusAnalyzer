using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using IndianStateCensusAnalyzer.POCO;
using IndianStateCensusAnalyzer;


namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "state,population,area,density";
        static string indianStateCensusFilePath = @"C:\Users\Sandeep\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndianStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"";
        static string wrongIndianStateCensusFileType = @"C:\Users\Sandeep\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\wrongIndianStateCensusFileType.txt";
        static string wrongDelimiterIndianCensusFilePath = @"C:\Users\Sandeep\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\wrongDelimiterIndianCensusFilePath.csv";
        static string wrongHeaderIndianStateCensusFile = @"C:\Users\Sandeep\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\wrongHeaderIndianStateCensusFile.csv";

        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeFilePath = @"C:\Users\Sandeep\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndianStateCode.csv";
        static string wrongIndianStateCodeFilePath = @"";
        static string wrongIndianStateCodeFileType = @"C:\Users\Sandeep\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\wrongIndianStateCodeFileType.txt";
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\Sandeep\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\wrongDelimiterIndianStateCodeFilePath.csv";
        static string wrongHeaderIndianStateCodeFile = @"C:\Users\Sandeep\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\wrongHeaderIndianStateCodeFile.csv";


        IndianStateCensusAnalyzer.CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        // Count
        // TC 1.1
        [Test]
        public void Test1()
        {
            totalRecord = censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(9, totalRecord.Count);
        }
        // TC 2.1
        [Test]
        public void GivenIndianCodeFilePath_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(10, stateRecord.Count);
        }
        //WrongFilePath
        //TC 1.2
        [Test]
        public void GivenWrongIndianCensusCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        //TC 2.2
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        //WrongFileType
        //TC 1.3
        [Test]
        public void GivenWrongIndianStateCensusFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        //TC 2.3 
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.eType);
        }

        //FileWithWrongDelimeter
        //TC 1.4
        [Test]
        public void GivenWrongIndianCensusDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongDelimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        //TC 2.4
        [Test]
        public void GivenWrongIndianStateCodeDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongDelimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.eType);
        }
        //WrongHeader
        //TC 1.5
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongHeaderIndianStateCensusFile, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        //TC 2.5
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongHeaderIndianStateCodeFile, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateCodeException.eType);
        }
    }
}

