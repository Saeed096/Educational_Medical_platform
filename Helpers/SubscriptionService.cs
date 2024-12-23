namespace Educational_Medical_platform.Helpers
{
    public class SubscriptionService : ISubscriptionService
    {
        public SubscriptionService() { }


        public DateTime getEnddate(DateTime enddate)
        {
            if (enddate.Day > DateTime.Today.Day)
            {
                // use isdayfoundinmonth before build date

                if (isDayFoundInMonth(enddate.Day, DateTime.Today.Month))
                {
                    enddate = new DateTime(DateTime.Today.Year
                    , DateTime.Today.Month, enddate.Day);
                }
                else
                {
                    if (DateTime.Today.Month != 12)
                    {
                        enddate = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1);
                    }
                    else
                    {
                        enddate = new DateTime(DateTime.Today.Year + 1, 1, 1);

                    }
                }

            }
            else
            {
                if (DateTime.Today.Month != 12)
                {
                    if (isDayFoundInMonth(enddate.Day, DateTime.Today.Month + 1))
                    {
                        enddate = new DateTime(DateTime.Today.Year,
                            DateTime.Today.Month + 1, enddate.Day);
                    }
                    else
                    {
                        if (DateTime.Today.Month != 11)
                        {
                            enddate = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 2, 1);
                        }
                        else
                        {
                            enddate = new DateTime(DateTime.Today.Year + 1, 1, 1);
                        }
                    }

                }
                else
                {
                    if (isDayFoundInMonth(enddate.Day, 1))
                    {
                        enddate = new DateTime(DateTime.Today.Year + 1,
                      1, enddate.Day);
                    }
                    else
                    {
                        enddate = new DateTime(DateTime.Today.Year + 1, 2, 1);
                    }

                }
            }
            return enddate;
        }



        private bool isDayFoundInMonth(int day, int month)
        {
            int[] largeMonths = { 1, 3, 5, 7, 8, 10, 12 }; // months that contain 31 day
            int[] smallMonths = { 4, 6, 9, 11 };  // months that contain 30 day

            if (largeMonths.Contains(month))
            {
                return true;
            }
            else if (smallMonths.Contains(month))
            {
                if (day > 30)
                {
                    return false;
                }
                return true;
            }
            else // handle februaury case
            {
                if (DateTime.IsLeapYear(DateTime.Today.Year))
                {
                    if (day <= 29)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (day <= 28)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }
}
