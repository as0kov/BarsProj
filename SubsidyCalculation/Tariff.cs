using System;

namespace SubsidyCalculation
{
    /// <summary>
    /// Тариф
    /// </summary>
    public class Tariff
    {
        public Tariff(int serviceId, int houseId, DateTime periodBegin, DateTime periodEnd, decimal value)
        {
            ServiceId = serviceId;
            HouseId = houseId;
            PeriodBegin = periodBegin;
            PeriodEnd = periodEnd;
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
        /// Месяц начала действия периода тарифа
        /// </summary>
        public DateTime PeriodBegin { get; set; }
        
        /// <summary>
        /// Месяц конец действия периода тарифа
        /// </summary>
        public DateTime PeriodEnd { get; set; }
        
        
        /// <summary>
        /// Значение тарифа
        /// </summary>
        public decimal Value { get; set; }
    }
}