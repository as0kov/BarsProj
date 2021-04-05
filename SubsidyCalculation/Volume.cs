using System;

namespace SubsidyCalculation
{
    /// <summary>
    /// Объём
    /// </summary>
    public class Volume
    {
        public Volume(int serviceId, int houseId, DateTime month, decimal value)
        {
            ServiceId = serviceId;
            HouseId = houseId;
            Month = month;
            Value = value;
        }

        /// <summary>
        /// Идентификатор услуги
        /// </summary>
        public int ServiceId { get; set; }
        
        /// <summary>
        /// Идентификатор дома
        /// </summary>
        public int HouseId { get; set; }
        
        /// <summary>
        /// Месяц начисления
        /// </summary>
        public DateTime Month { get; set; }
        
        /// <summary>
        /// Значение объёма
        /// </summary>
        public decimal Value { get; set; }
    }
}