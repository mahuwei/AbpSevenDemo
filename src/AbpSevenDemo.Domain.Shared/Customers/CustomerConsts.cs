namespace AbpSevenDemo.Customers
{
    public static class CustomerConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Customer." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int MobileNumberMaxLength = 20;
        public const int EmailMaxLength = 50;
        public const int AddressMaxLength = 200;
    }
}