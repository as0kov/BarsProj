using System;

namespace SubsidyCalculation
{
    class SubsidyCalculator : ISubsidyCalculation
    {
        public event EventHandler<string> OnNotify;
        public event EventHandler<Tuple<string, Exception>> OnException;

        public Charge CalculateSubsidy(Volume volumes, Tariff tariff)
        {
            Notify($"Расчёт начат в {DateTime.Now}");

            try
            {
                if (
                Validate((volumes, tariff), x => x.Item1 != null, "Volume must not be null")
                & Validate((volumes, tariff), x => x.Item2 != null, "Tariff must not be null")
                && Validate((volumes, tariff), x => x.Item2.Value > 0, "Tariff value must be positive")
                & Validate((volumes, tariff), x => x.Item1.Value >= 0, "Volume value must be 0 or greater")
                & Validate((volumes, tariff), x => x.Item1.HouseId == x.Item2.HouseId, "HouseId not equal")
                & Validate((volumes, tariff), x => x.Item1.ServiceId == x.Item2.ServiceId, "ServiceId not equal")
                & Validate((volumes, tariff), x => x.Item1.Month >= x.Item2.PeriodBegin & x.Item1.Month <= x.Item2.PeriodEnd, "Volume month not included in tariff"))
                {
                    Notify($"Расчёт успешно завершен в {DateTime.Now}");
                    return new Charge(volumes.ServiceId, volumes.HouseId, DateTime.Now, volumes.Value * tariff.Value);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                OnException?.Invoke(this, new Tuple<string, Exception>(null, e));
                return null;
            }
        }

        public void Notify(string message)
        {
            OnNotify?.Invoke(this, message);
        }
        public bool Validate((Volume, Tariff) args, Func<(Volume, Tariff), bool> validator, string errorMessage)
        {
            var validationResult = validator.Invoke(args);
            if (!validationResult)
            {
                var ex = new Exception(errorMessage);
                OnException?.Invoke(this, new Tuple<string, Exception>(null, ex));
            }
            return validationResult;
        }
    }
}