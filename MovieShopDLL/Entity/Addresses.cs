namespace MovieShopDLL.Entity
{
    public class Addresses : AbsstractEntity
    {
        public string Street { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public string DisplayName => Street + " " + Country +" "+ ZipCode;
    }
}
