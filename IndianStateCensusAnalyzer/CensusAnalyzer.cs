using System;
using IndianStateCensusAnalyzer.POCO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace IndianStateCensusAnalyzer
{
   public class CensusAnalyzer
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
