using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyzer.POCO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public CensusDTO(StateCodeDAO stateCodeDAO)
        {
            this.serialNumber = stateCodeDAO.serialNumber;
            this.stateName = stateCodeDAO.stateName;
            this.tin = stateCodeDAO.tin;
            this.stateCode = stateCodeDAO.stateCode;
        }
        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }

        //public CensusDTO(USCensusDAO usCensusDao)
        //{
        //    this.stateCode = usCensusDao.stateId;
        //    this.stateName = usCensusDao.stateName;
        //    this.population = usCensusDao.population;
        //    this.housingUnits = usCensusDao.housingUnits;
        //    this.totalArea = usCensusDao.totalArea;
        //    this.waterArea = usCensusDao.waterArea;
        //    this.landArea = usCensusDao.landArea;
        //}
    }
}
